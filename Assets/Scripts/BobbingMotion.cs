using UnityEngine;
using System.Collections;

public class BobbingMotion : MonoBehaviour
{

	public float range = .4f	;
	public float rangeChangePerSecond = .06f;
	bool rangeGoingUp = true;
	float rangeAmount = 0;
	
	void FixedUpdate () {
		if (rangeGoingUp) {
			rangeAmount += rangeChangePerSecond;
			var newY = transform.position.y + rangeChangePerSecond;
			transform.position = new Vector3(transform.position.x, newY, transform.position.z);
			if (rangeAmount > range) {
				rangeGoingUp = false;
			}
		}
		
		if (!rangeGoingUp) {
			rangeAmount -= rangeChangePerSecond;
			var newY = transform.position.y - rangeChangePerSecond;
			transform.position = new Vector3(transform.position.x, newY, transform.position.z);
			if (rangeAmount < -range) {
				rangeGoingUp = true;
			}
		}
	}
}
