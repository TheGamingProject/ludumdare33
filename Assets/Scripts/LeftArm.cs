
using UnityEngine;
using System.Collections;

public class LeftArm : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D collider) {
		transform.parent.GetComponent<Controls> ().hitLeftArm (collider);
	}
}

