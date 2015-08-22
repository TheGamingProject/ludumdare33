using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Controls : MonoBehaviour
{
	//int direction = 0;
	//SpriteRenderer mySprite;

	Transform leftArm;
	Transform rightArm;
	
	public float switchSidesCooldownAmount = .150f;
	Cooldown gotoLeftCooldown;
	Cooldown gotoRightCooldown;

	public float swingCooldownAmount = .150f;
	Cooldown swingCooldown;

	void Start()
	{
		//mySprite = transform.GetComponent<SpriteRenderer> ();

		leftArm = transform.GetChild (0);
		rightArm = transform.GetChild (1);

		gotoLeftCooldown = new Cooldown (switchSidesCooldownAmount);
		gotoRightCooldown = new Cooldown (switchSidesCooldownAmount);
		swingCooldown = new Cooldown (swingCooldownAmount);

		gotoIdle ();
	}

		
	void Update()
	{
		if (gotoLeftCooldown.didCooldownExpire()) {
			gotoLeft();
			GetComponent<Animator> ().Play ("monster_attack_left");
			gotoLeftCooldown.stopCooldown();
		}
		if (gotoRightCooldown.didCooldownExpire()) {
			gotoRight();
			GetComponent<Animator> ().Play ("monster_attack_right");
			gotoRightCooldown.stopCooldown();
		}

		if (swingCooldown.didCooldownExpire ()) {
			gotoIdle();
			swingCooldown.stopCooldown();
		}
	}
	
	public void pressLeft () {
		gotoLeftCooldown.startCooldown ();
		gotoIdle();
		gotoRightCooldown.stopCooldown ();
	}

	public void releaseLeft () {
		//gotoIdle();
	}

	public void pressRight () {
		gotoRightCooldown.startCooldown();
		gotoIdle();
		gotoLeftCooldown.stopCooldown();
	}
	
	public void releaseRight () {
		//gotoIdle();
	}

	void gotoIdle () {
		leftArm.GetComponent<BoxCollider2D>().enabled = false;
		rightArm.GetComponent<BoxCollider2D>().enabled = false;
	//	direction = 0;
	}

	void gotoLeft () {
		leftArm.GetComponent<BoxCollider2D>().enabled = true;
	//	direction = -1;
		swingCooldown.startCooldown();
	}

	void gotoRight () {
		rightArm.GetComponent<BoxCollider2D>().enabled = true;
	//	direction = 1;
		swingCooldown.startCooldown();
	}

	public void hitLeftArm(Collider2D collider) {
		normalHitCollider (collider);
	}

	public void hitRightArm(Collider2D collider) {
		normalHitCollider (collider);
	}

	void normalHitCollider (Collider2D collider) {
		//	Debug.Log (collider.name);
		if (collider.GetComponent<Building>() != null) {
			if (collider.GetComponent<Building>() is ColoredBuilding) {
				collider.GetComponent<ColoredBuilding>().die ();
			} else {
				collider.GetComponent<Building>().die();
			}
		}
	}
}
