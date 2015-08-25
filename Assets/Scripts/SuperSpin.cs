using UnityEngine;
using System.Collections;

public class SuperSpin : MonoBehaviour
{
	public Vector3 speed;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(new Vector3(speed.x, speed.y, speed.z));
	}
}

