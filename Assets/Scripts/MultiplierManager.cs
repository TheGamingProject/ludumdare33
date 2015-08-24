using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MultiplierManager : MonoBehaviour
{
	public Sprite blueIndicator;
	public Sprite greenIndicator;
	public Sprite redIndicator;
	public Sprite orangeIndicator;

	AudioSource audioSource;
	public AudioClip combo2Sound;
	public AudioClip combo3Sound;
	public AudioClip combo4Sound;
	public AudioClip combo5Sound;
	
	List<Transform> boxes = new List<Transform> ();
	List<Transform> stars = new List<Transform> ();
	
	Dictionary<Colors, Sprite> colorIndicators = new Dictionary<Colors, Sprite>();
	
	List<Colors> colorPicks;
	int comboSetAmount = 2;
	int onBoxNumber = 0;

	int multiplier = 1;

	public float x5MultiplierCooldownAmount = 10f;

	public float comboCompleteCooldownAmount = 5f;

	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
		x5MultiplierCooldown = new Cooldown (x5MultiplierCooldownAmount);
		comboCompleteCooldown = new Cooldown (comboCompleteCooldownAmount);

		boxes.Add(transform.GetChild (0));
		boxes.Add(transform.GetChild (1));
		boxes.Add(transform.GetChild (2));
		boxes.Add(transform.GetChild (3));
		boxes.Add(transform.GetChild (4));

		stars.Add (transform.GetChild (5));
		stars.Add (transform.GetChild (6));
		stars.Add (transform.GetChild (7));
		stars.Add (transform.GetChild (8));
		stars.Add (transform.GetChild (9));

		colorIndicators.Add (Colors.Blue, blueIndicator);
		colorIndicators.Add (Colors.Green, greenIndicator);
		colorIndicators.Add (Colors.Orange, orangeIndicator);
		colorIndicators.Add (Colors.Red, redIndicator);
		
		disableAll ();
		startMultiplierSet (2);

		updateMultiplier ();
	}

	float getTwoDecimalPlaces (float f) {
		return (float)Mathf.RoundToInt (f * 100) / 100.0f;
	}

	// Update is called once per frame
	void Update ()
	{
		float x5TimeLeft = getTwoDecimalPlaces(this.getX5MultiplierTime ());

		if (x5TimeLeft == -1) {
			GameObject.Find("ComboGlow").GetComponent<Image>().enabled = false;
			GameObject.Find ("x5Multiplier").GetComponent<Text> ().text = "";
		} else {
			GameObject.Find("ComboGlow").GetComponent<Image>().enabled = true;
			GameObject.Find ("x5Multiplier").GetComponent<Text> ().text = "" + x5TimeLeft;
		}

		if (x5MultiplierCooldown.didCooldownExpire ()) {
			deMultiply();
		}

		if (comboCompleteCooldown.didCooldownExpire ()) {
			turnOffComboComplete();
		}
	}
	
	void startMultiplierSet(int amount) {
		if (amount > 5) {
			amount = 5;
		}
		comboSetAmount = amount;
		colorPicks = new List<Colors>();
		for (int i=0; i<amount; i++) {
			colorPicks.Add((Colors)Random.Range(0,4));
		}
		for (int i=0; i<amount; i++) {
			boxes[i].GetComponent<Image>().enabled = true;
			boxes[i].GetComponent<Image>().sprite = colorIndicators[colorPicks[i]];
		}
		setMultiplierColorIndicatorsToNew (amount);

		onBoxNumber = 0;
	}

	void setMultiplierColorIndicatorsToNew (float amount) {
		for (int i=0; i<amount; i++) {
			boxes[i].GetComponent<Image>().enabled = true;
			boxes[i].GetComponent<Image>().sprite = colorIndicators[colorPicks[i]];
		}
	}
	
	public void hitColoredBuilding (Colors color) {
		//Debug.Log (color + " hit me");
		if (color == getColorNeeded()) {
			// check box and move on
			//   if box is last in combo, move multiplier up and start new combo

			stars[onBoxNumber].GetComponent<Image>().enabled = true;
			onBoxNumber++;

			if (onBoxNumber == comboSetAmount) {
				// combo completed
				comboCompleted(comboSetAmount);
			}
		} else {
			// if current box is first move multiplier down, if not reset combo
			if (onBoxNumber == 0) {
				// delevel
				deMultiply();
			} else {
				// reset combo
				resetCombo();
			}
		}
	}
	
	void disableAll () {
		boxes[0].GetComponent<Image> ().enabled = false;
		boxes[1].GetComponent<Image> ().enabled = false;
		boxes[2].GetComponent<Image> ().enabled = false;
		boxes[3].GetComponent<Image> ().enabled = false;
		boxes[4].GetComponent<Image> ().enabled = false;
		disableStars ();
	}

	void disableStars () {
		stars[0].GetComponent<Image>().enabled = false;
		stars[1].GetComponent<Image>().enabled = false;
		stars[2].GetComponent<Image>().enabled = false;
		stars[3].GetComponent<Image>().enabled = false;
		stars[4].GetComponent<Image>().enabled = false;
	}

	void comboCompleted (int num) {
		GameObject.Find ("GameTimer").GetComponent<GameTimer> ().addTime (multiplier);

		multiplier += 1;
		updateMultiplier ();
		
		disableAll ();
	
		if (multiplier >= 5) {
			x5MultiplierCooldown.startCooldown ();
			startMultiplierSet (5);
		} else {
			startMultiplierSet (num + 1);
		}

		playComboSound ();

		onBoxNumber = 0;
	}

	void deMultiply () {
		x5MultiplierCooldown.stopCooldown();
		if (multiplier > 1) {
			multiplier--;
			updateMultiplier ();
		}
		
		disableAll ();
		startMultiplierSet (multiplier + 1);

		if (multiplier > 5) {
			x5MultiplierCooldown.startCooldown();
		}
	}

	void resetCombo () {
		setMultiplierColorIndicatorsToNew (comboSetAmount);
		disableStars ();
		onBoxNumber = 0;
	}

	public float baseSpeed = 4.0f;
	public float perMultiplierSpeed = .5f;
	void updateMultiplier() {
		GameObject.Find ("Score").GetComponent<Score> ().setMultiplier (multiplier);
		float newSpeed = baseSpeed + multiplier * perMultiplierSpeed;
		GameObject.Find ("2 - Game Object Foreground").GetComponent<LevelSpeed> ().baseSpeed = newSpeed;
		GameObject.Find ("0 - Background").GetComponent<LevelSpeed> ().baseSpeed = newSpeed;
	}

	Cooldown x5MultiplierCooldown;
	float getX5MultiplierTime () {
		return x5MultiplierCooldown.getTimeLeft();
	}

	public Colors getColorNeeded() {
		return colorPicks [onBoxNumber];
	}

	void playComboSound () {
		AudioClip audioClip = null;
		int i = multiplier;
		i = i > 5 ? 5 : i;
		i = i < 2 ? 2 : i;

		switch (multiplier) {
		case 2:
			audioClip = combo2Sound;
			break;
		case 3:
			audioClip = combo3Sound;
			break;
		case 4:
			audioClip = combo4Sound;
			break;
		case 5:
			audioClip = combo5Sound;
			break;
		}

		audioSource.clip = audioClip;
		audioSource.Play ();
		turnOnComboComplete ();
	}

	Cooldown comboCompleteCooldown;
	void turnOnComboComplete () {
		GameObject.Find ("ComboComplete").GetComponent<SpriteRenderer> ().enabled = true;
		comboCompleteCooldown.startCooldown ();
	}

	void turnOffComboComplete () {
		GameObject.Find ("ComboComplete").GetComponent<SpriteRenderer> ().enabled = false;
		comboCompleteCooldown.stopCooldown ();
	}
}

