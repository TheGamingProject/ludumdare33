using UnityEngine;
using System.Collections;

public class ScrollingCombatText : MonoBehaviour
{
	public Vector2 speed = new Vector2(0.0f, 1.0f);
	public float timeTilDeath = 3.0f;

	Cooldown deathCooldown;

	// Use this for initialization
	void Start ()
	{
		deathCooldown = new Cooldown (timeTilDeath);
		deathCooldown.startCooldown ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3(transform.position.x + Time.deltaTime * speed.x, transform.position.y + Time.deltaTime * speed.y, transform.position.z);

		if (deathCooldown.didCooldownExpire ()) {
			Destroy(gameObject);
		}
	}
}

