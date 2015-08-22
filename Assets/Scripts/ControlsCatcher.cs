using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ControlsCatcher : MonoBehaviour
{
	public Transform playerMonster;

	float lastDirection = 0;

	void Update () {
		float direction = 0;

		if (Input.GetKeyDown ("a")) {
			playerMonster.GetComponent<Controls>().pressLeft();
		}
		if (Input.GetKeyUp ("a")) {
			playerMonster.GetComponent<Controls>().releaseLeft();
		}

		if (Input.GetKeyDown ("d")) {
			playerMonster.GetComponent<Controls>().pressRight();
		}
		if (Input.GetKeyUp ("d")) {
			playerMonster.GetComponent<Controls>().releaseRight();
		}

		lastDirection = direction;
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
	
}