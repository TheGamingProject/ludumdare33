using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

	void Update () {
		if (Input.GetKeyDown ("z")) {
			Application.LoadLevel("basic");
		}
	}
}

