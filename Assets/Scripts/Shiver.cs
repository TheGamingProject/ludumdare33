using UnityEngine;
using System.Collections;

public class Shiver : MonoBehaviour
{
	public float range = .2f;
	public float rangeChangePerSecond = .06f;
	bool rangeGoingUp = true;
	float rangeAmount = 0;
	
	void FixedUpdate () {
		if (rangeGoingUp) {
			rangeAmount += rangeChangePerSecond;
			float newXYScale = transform.localScale.x + rangeChangePerSecond;

			transform.localScale = new Vector3(newXYScale, newXYScale, transform.localScale.z);

			if (rangeAmount > range) {
				rangeGoingUp = false;
			}
		}
		
		if (!rangeGoingUp) {
			rangeAmount -= rangeChangePerSecond;
			float newXYScale = transform.localScale.x - rangeChangePerSecond;

			transform.localScale = new Vector3(newXYScale, newXYScale, transform.localScale.z);

			if (rangeAmount < -range) {
				rangeGoingUp = true;
			}
		}
	}
}

