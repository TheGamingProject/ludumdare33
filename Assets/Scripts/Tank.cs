using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour
{
	public float speed = 10f;

	bool haveCrashed = false, haveShooted;
	public float shootY = -36;
	public float crashY = -40;
	
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

		if (!haveShooted && transform.position.y < shootY) {
			shoot();
		}
		
		if (!haveCrashed && transform.position.y < crashY) {
			crash ();
		}
		
		if (haveCrashed) {
			float a = 0f;
			Vector3 newPosition = new Vector3 (transform.position.x - (a), transform.position.y - Time.deltaTime * -1 * levelSpeed.baseSpeed, 0);
			transform.position = newPosition;
		} else {
			if (transform.position.y > crashY) {
				float shootMultiplier = haveShooted ? .5f : 1f;
				transform.position = new Vector3 (transform.position.x, transform.position.y - Time.deltaTime * speed * shootMultiplier, 0);
			}
		}
	}
	
	Cooldown disappearCooldown = new Cooldown(30);
	void crash() {
		GetComponent<Animator> ().Play ("tank_crash");

		haveCrashed = true;
		
		disappearCooldown.startCooldown ();
	}

	void shoot() {
		GetComponent<Animator> ().Play ("tank_shoot");
		
		haveShooted = true;
	}
}
