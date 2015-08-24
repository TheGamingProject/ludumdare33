using UnityEngine;
using System.Collections;

public class ScorePasser : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Object.DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	int totalScore;
	int totalCombos;
	public void setScores (int total, int combos) {
		totalScore = total;
		totalCombos = combos;
	}

	public int getTotalScore() {
		return totalScore;
	}
	public int getTotalCombos() {
		return totalCombos;
	}

	int greenSass = 0;
	int redSass = 0;
	int blueSass = 0;
	int orangeSass = 0;

	public void upOneGreen () {
		greenSass++;
	}
	public void upOneRed () {
		redSass++;
	}
	public void upOneBlue () {
		blueSass++;
	}
	public void upOneOrange () {
		orangeSass++;
	}

	public int getGreenSass() {
		return greenSass;
	}
	public int getRedSass() {
		return redSass;
	}
	public int getBlueSass() {
		return blueSass;
	}
	public int getOrangeSass() {
		return orangeSass;
	}
}

