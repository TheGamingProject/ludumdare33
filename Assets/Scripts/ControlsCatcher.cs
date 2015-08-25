using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ControlsCatcher : MonoBehaviour
{
	public Transform playerMonster;
	bool gameOver = false;
	bool isMuted = false;

	void Update () {
		if (gameOver)
			return;

		if (Input.GetKeyDown ("a") || Input.GetKeyDown ("left")) {
			playerMonster.GetComponent<Controls>().pressLeft();
		}
		if (Input.GetKeyUp ("a") || Input.GetKeyUp("left")) {
			playerMonster.GetComponent<Controls>().releaseLeft();
		}

		if (Input.GetKeyDown ("d") || Input.GetKeyDown("right")) {
			playerMonster.GetComponent<Controls>().pressRight();
		}
		if (Input.GetKeyUp ("d") || Input.GetKeyUp("right")) {
			playerMonster.GetComponent<Controls>().releaseRight();
		}

		if (Input.GetKeyUp ("m")) {
			if (isMuted) {
				AudioListener.volume = 1;
			} else {
				AudioListener.volume = 0;
			}
		}
	}
	
	void OnGUI () {
		/*
		int buttonWidth = Screen.width / 2;
		int buttonHeight = (Screen.height / 8);
		bool modified = false;
		
		if (
			GUI.RepeatButton(
			new Rect(
			0,
			Screen.height * 6 / 8,
			buttonWidth,
			buttonHeight
			),
			"LEFT"
			)
			)
		{
			modified = true;
			playerMonster.GetComponent<Controls>().hitDirection(-1);
		} 
		if (
			GUI.RepeatButton(
			new Rect(
			buttonWidth,
			(Screen.height * 6 / 8),
			buttonWidth,
			buttonHeight
			),
			"RIGHT"
			)
			)
		{
			modified = true;
			playerMonster.GetComponent<Controls>().hitDirection(1);
		} 
		
		if (modified == false) {
			playerMonster.GetComponent<Controls>().release();
		}
		*/
	}

	public void setGameOver () {
		gameOver = true;
	}
	
}