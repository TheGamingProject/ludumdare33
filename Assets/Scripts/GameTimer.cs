using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{
	float timeLeft = 30;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		timeLeft -= Time.deltaTime;

		GetComponent<Text> ().text = Mathf.Floor (timeLeft) + " seconds";

		if (timeLeft < 0) {
			setGameOver();
		}
	}

	public void addTime(int amount) {
		if (amount == 5) {
			timeLeft += 1;
		}
		if (amount == 1) {
			timeLeft += .3f;
		}
	}

	public void setGameOver() {
		GameObject.Find("Main Camera").GetComponent<ControlsCatcher>().setGameOver();
		GameObject.Find ("2 - Game Object Foreground").GetComponent<LevelSpeed> ().baseSpeed = 0;
		GameObject.Find ("0 - Background").GetComponent<LevelSpeed> ().baseSpeed = 0;
	}
}

