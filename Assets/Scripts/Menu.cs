using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

	void Update () {
		if (Input.GetKeyDown ("z") || Input.GetKeyDown("enter")) {
			Application.LoadLevel("basic");
		}
	}
}

