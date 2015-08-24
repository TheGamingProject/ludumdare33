using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	public float speed = 3f; 

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (stop)
			return;

		transform.Rotate(new Vector3(0, 0, speed));

		if (stopping && Mathf.Abs(transform.rotation.z) < .05f) {
			stop = true;
		}
	}
	bool stopping = false, stop = false;
	public void stopSpinning () {
		stopping = true;
	}
}
