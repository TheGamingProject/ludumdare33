using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Controls : MonoBehaviour
{
	public Sprite idleSprite;
	public Sprite leftSprite;
	public Sprite rightSprite;

	int direction = 0;
	SpriteRenderer mySprite;

	Transform leftArm;
	Transform rightArm;
	
	public float switchSidesCooldownAmount = .150f;
	Cooldown gotoLeftCooldown;
	Cooldown gotoRightCooldown;

	void Start()
	{
		mySprite = transform.GetComponent<SpriteRenderer> ();

		leftArm = transform.GetChild (0);
		rightArm = transform.GetChild (1);

		gotoLeftCooldown = new Cooldown (switchSidesCooldownAmount);
		gotoRightCooldown = new Cooldown (switchSidesCooldownAmount);

		gotoIdle ();
	}

		
	void Update()
	{
		if (gotoLeftCooldown.didCooldownExpire()) {
			gotoLeft();
			gotoLeftCooldown.stopCooldown();
		}
		if (gotoRightCooldown.didCooldownExpire()) {
			gotoRight();
			gotoRightCooldown.stopCooldown();
		}


	}
	
	public void pressLeft () {
		gotoLeftCooldown.startCooldown ();
		gotoIdle();
		gotoRightCooldown.stopCooldown ();
	}

	public void releaseLeft () {
		gotoIdle();
	}

	public void pressRight () {
		gotoRightCooldown.startCooldown();
		gotoIdle();
		gotoLeftCooldown.stopCooldown();
	}
	
	public void releaseRight () {
		gotoIdle();
	}

	void gotoIdle () {
		mySprite.sprite = idleSprite;
		leftArm.GetComponent<BoxCollider2D>().enabled = false;
		rightArm.GetComponent<BoxCollider2D>().enabled = false;
		direction = 0;
	}

	void gotoLeft () {
		mySprite.sprite = leftSprite;
		leftArm.GetComponent<BoxCollider2D>().enabled = true;
		direction = -1;
	}

	void gotoRight () {
		mySprite.sprite = rightSprite;
		rightArm.GetComponent<BoxCollider2D>().enabled = true;
		direction = 1;
	}

	public void hitLeftArm(Collider2D collider) {
		Debug.Log (collider.name);
		if (collider.GetComponent<Building>() != null) {
			collider.GetComponent<Building>().die();
		}
	}

	public void hitRightArm(Collider2D collider) {
		Debug.Log (collider.name);
		if (collider.GetComponent<Building>() != null) {
			collider.GetComponent<Building>().die();
		}
	}
}
