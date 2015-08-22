using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MultiplierManager : MonoBehaviour
{
	public Sprite blueIndicator;
	public Sprite blueIndicatorChecked;
	public Sprite greenIndicator;
	public Sprite greenIndicatorChecked;
	public Sprite redIndicator;
	public Sprite redIndicatorChecked;
	public Sprite orangeIndicator;
	public Sprite orangeIndicatorChecked;
	
	
	List<Transform> boxes = new List<Transform> ();
	
	Dictionary<Colors, Sprite> colorIndicators = new Dictionary<Colors, Sprite>();
	Dictionary<Colors, Sprite> colorIndicatorsChecked = new Dictionary<Colors, Sprite>();
	
	List<Colors> colorPicks;
	int comboSetAmount = 2;
	int onBoxNumber = 0;

	int multiplier = 1;
	
	// Use this for initialization
	void Start ()
	{
		boxes.Add(transform.GetChild (0));
		boxes.Add(transform.GetChild (1));
		boxes.Add( transform.GetChild (2));
		boxes.Add(transform.GetChild (3));
		boxes.Add(transform.GetChild (4));
		
		
		colorIndicators.Add (Colors.Blue, blueIndicator);
		colorIndicators.Add (Colors.Green, greenIndicator);
		colorIndicators.Add (Colors.Orange, orangeIndicator);
		colorIndicators.Add (Colors.Red, redIndicator);
		colorIndicatorsChecked.Add (Colors.Blue, blueIndicatorChecked);
		colorIndicatorsChecked.Add (Colors.Green, greenIndicatorChecked);
		colorIndicatorsChecked.Add (Colors.Orange, orangeIndicatorChecked);
		colorIndicatorsChecked.Add (Colors.Red, redIndicatorChecked);
		
		disableAll ();
		startMultiplierSet (2);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void startMultiplierSet(int amount) {
		comboSetAmount = amount;
		colorPicks = new List<Colors>();
		for (int i=0; i<amount; i++) {
			colorPicks.Add((Colors)Random.Range(0,4));
		}
		for (int i=0; i<amount; i++) {
			boxes[i].GetComponent<Image>().enabled = true;
			boxes[i].GetComponent<Image>().sprite = colorIndicators[colorPicks[i]];
		}
		onBoxNumber = 0;
	}
	
	public void hitColoredBuilding (Colors color) {
		if (multiplier == 5) {
			return;
		}

		Debug.Log (color + " hit me");
		if (color == colorPicks [onBoxNumber]) {
			// check box and move on
			//   if box is last in combo, move multiplier up and start new combo
			

			boxes[onBoxNumber].GetComponent<Image>().sprite = colorIndicatorsChecked[colorPicks[onBoxNumber]];
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
	}

	void comboCompleted (int num) {
		multiplier += 1;
		updateMultiplier ();

		if (multiplier >= 5) {
			return;
		}

		disableAll ();
		startMultiplierSet (num + 1);

		onBoxNumber = 0;
	}

	void deMultiply () {
		if (multiplier > 1) {
			multiplier--;
			updateMultiplier ();
		}
		
		disableAll ();
		startMultiplierSet (multiplier + 1);
	}

	void resetCombo () {
		startMultiplierSet (comboSetAmount);
	}

	public float baseSpeed = 4.0f;
	public float perMultiplierSpeed = .5f;
	void updateMultiplier() {
		GameObject.Find ("Score").GetComponent<Score> ().setMultiplier (multiplier);
		float newSpeed = baseSpeed + multiplier * perMultiplierSpeed;
		GameObject.Find ("2 - Game Object Foreground").GetComponent<LevelSpeed> ().baseSpeed = newSpeed;
		GameObject.Find ("0 - Background").GetComponent<LevelSpeed> ().baseSpeed = newSpeed;
	}
}

