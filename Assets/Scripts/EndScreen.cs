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
		GameObject.Find ("TotalScore").GetComponent<Text> ().text = "" + totalScore;	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

