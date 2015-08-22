using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Building : MonoBehaviour
{
	public int deathPoints = 1;

	public void die () {
		GetComponent<Animator> ().SetBool ("isDead", true);
		GameObject.Find ("Score").GetComponent<Score> ().givePoints (deathPoints);
	}
}
