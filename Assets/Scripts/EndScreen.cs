using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScreen : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		ScorePasser sp = GameObject.Find ("ScorePasser").GetComponent<ScorePasser> ();
		int totalScore = sp.getTotalScore ();
		int totalCombos = sp.getTotalCombos ();
		int redSass = sp.getRedSass ();
		int greenSass = sp.getGreenSass ();
		int orangeSass = sp.getOrangeSass ();
		int blueSass = sp.getBlueSass ();

		GameObject.Find ("TotalScore").GetComponent<Text> ().text = "" + totalScore;
		GameObject.Find ("TotalCombos").GetComponent<Text> ().text = "" + totalCombos;	
		GameObject.Find ("RedSass").GetComponent<Text> ().text = "" + redSass;
		GameObject.Find ("GreenSass").GetComponent<Text> ().text = "" + greenSass;	
		GameObject.Find ("OrangeSass").GetComponent<Text> ().text = "" + orangeSass;
		GameObject.Find ("BlueSass").GetComponent<Text> ().text = "" + blueSass;	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("z")) {
			Application.LoadLevel("start");
		}
	}
}

