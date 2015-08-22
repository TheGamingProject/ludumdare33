
using UnityEngine;
using System.Collections;

public class RightArm : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D collider) {
		transform.parent.GetComponent<Controls> ().hitRightArm (collider);
	}
}

