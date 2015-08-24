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
	public void setScores (int total) {
		totalScore = total;
	}

	public int getTotalScore() {
		return totalScore;
	}

}

