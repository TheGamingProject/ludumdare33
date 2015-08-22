using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Building : MonoBehaviour
{

	public void die () {
		GetComponent<Animator> ().SetBool ("isDead", true);
	}
}
