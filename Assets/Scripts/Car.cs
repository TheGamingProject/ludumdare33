using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{
	public float speed = 10f;

	public bool isGreen = false; 

	bool haveCrashed = false;
	public float crashY = -37;

	LevelSpeed levelSpeed;
	// Use this for initialization
	void Start ()
	{
		levelSpeed = transform.parent.GetComponent<LevelSpeed> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (disappearCooldown.didCooldownExpire ()) {
			Destroy(gameObject);
		}


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

	Cooldown disappearCooldown = new Cooldown(30);
	void crash() {
		//Debug.Log ("crash");
		if (isGreen) {
			GetComponent<Animator> ().Play ("car_green_crash");
		} else {
			GetComponent<Animator> ().Play ("car_purple_crash");
		}
		GetComponent<AudioSource> ().Play ();
		haveCrashed = true;

		disappearCooldown.startCooldown ();
	}
}

