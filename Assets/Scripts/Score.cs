﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	private int total = 0;

	private int multiplier = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void givePoints (int num, float seconds) {
		addTime (seconds);
		total += num * multiplier;
		redrawText ();
	}

	void addTime (float num) {
		GameObject.Find ("GameTimer").GetComponent<GameTimer> ().addTime (num);
	}

	public int getPoints () {
		return total;
	}

	public void setMultiplier (int num) {
		multiplier = num;
		redrawText ();
	}

	void redrawText () {
		GetComponent<Text> ().text = total + "  " + multiplier + "x";
	}

	public int getScore() {
		return total;
	}
}
