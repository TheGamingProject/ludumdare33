using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{
	float timeLeft = 30;

	public float startEndScreenCooldownAmount1 = 8;
	public float startEndScreenCooldownAmount2 = 10;
	Cooldown startEndScreenCooldown1;
	Cooldown startEndScreenCooldown2;
	bool gameOver = false;
	// Use this for initialization
	void Start ()
	{
		startEndScreenCooldown1 = new Cooldown (startEndScreenCooldownAmount1);
		startEndScreenCooldown2 = new Cooldown (startEndScreenCooldownAmount2);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (gameOver) {
			gameOverUpdate();
			return;
		}

		timeLeft -= Time.deltaTime;

		GetComponent<Text> ().text = Mathf.Floor (timeLeft) + " seconds";

		if (timeLeft < 0) {
			setGameOver();
		}

	}

	void gameOverUpdate () {
		if (startEndScreenCooldown1.didCooldownExpire ()) {
			GameObject.Find("EndScreenMessage").GetComponent<Spin>().stopSpinning();
		}
		
		if (startEndScreenCooldown2.didCooldownExpire ()) {
			int totalScore = GameObject.Find("Score").GetComponent<Score>().getScore();
			int totalCombos = GameObject.Find ("MultiplierManager").GetComponent<MultiplierManager>().getTotalCombos();
			
			GameObject.Find("ScorePasser").GetComponent<ScorePasser>().setScores(totalScore, totalCombos);
			Application.LoadLevel("end");
		}
	}

	public void addTime(float amount) {
		timeLeft += amount;
	}

	public void setGameOver() {
		gameOver = true;
		GameObject.Find("Main Camera").GetComponent<ControlsCatcher>().setGameOver();
		GameObject.Find ("2 - Game Object Foreground").GetComponent<LevelSpeed> ().baseSpeed = 0;
		GameObject.Find ("0 - Background").GetComponent<LevelSpeed> ().baseSpeed = 0;

		GetComponent<Text> ().text = "";

		GameObject.Find ("EndScreenMessage").GetComponent<SpriteRenderer> ().enabled = true;
		startEndScreenCooldown1.startCooldown ();
		startEndScreenCooldown2.startCooldown ();
		GetComponent<AudioSource> ().Play ();
	}

}

