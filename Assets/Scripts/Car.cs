using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{
	public float speed = 10f;

	bool haveCrashed = false;
	public float crashY = -37;

	LevelSpeed levelSpeed;
	// Use this for initialization
	void Start ()
	{
		levelSpeed = transform.parent.GetComponent<LevelSpeed> ();
		Debug.Log (levelSpeed);
	}
	
	// Update is called once per frame
	void Update ()
	{


		if (!haveCrashed && transform.position.y < crashY) {
			crash ();
		}

		if (haveCrashed) {
			float a = transform.position.x <= -6.84f ? 0 : .05f;
			Vector3 newPosition = new Vector3 (transform.position.x - (a), transform.position.y - Time.deltaTime * -1 * levelSpeed.baseSpeed, 0);
			transform.position = newPosition;
		} else {
			if (transform.position.y > crashY) {
				transform.position = new Vector3 (transform.position.x, transform.position.y - Time.deltaTime * speed, 0);
			}
		}
	}

	float crashTime;
	void crash() {
		Debug.Log ("crash");
		crashTime = Time.timeSinceLevelLoad;
		GetComponent<Animator> ().Play ("car_purple_crash");
		haveCrashed = true;
	}
}

