using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Controls : MonoBehaviour
{
	public Sprite idleSprite;
	public Sprite leftSprite;
	public Sprite rightSprite;

	float direction = 0;
	SpriteRenderer mySprite;

	Transform leftArm;
	Transform rightArm;

	void Start()
	{
		mySprite = transform.GetComponent<SpriteRenderer> ();

		leftArm = transform.GetChild (0);
		rightArm = transform.GetChild (1);

		gotoIdle ();
	}

	float gotoLeftCooldown = -1,
	gotoRightCooldown = -1;
		
	void Update()
	{
		if (gotoLeftCooldown > 0 && gotoLeftCooldown < Time.timeSinceLevelLoad) {
			gotoLeft();
			gotoLeftCooldown = -1;
		}
		if (gotoRightCooldown > 0 && gotoRightCooldown < Time.timeSinceLevelLoad) {
			gotoRight();
			gotoRightCooldown = -1;
		}
	}
	public float switchCooldownAmount = .150f;
	public void holdLeft () {
		gotoLeftCooldown = Time.timeSinceLevelLoad + switchCooldownAmount;
		gotoIdle();
		gotoRightCooldown = -1;
	}

	public void releaseLeft () {
		gotoIdle();
	}

	public void holdRight () {
		gotoRightCooldown = Time.timeSinceLevelLoad + switchCooldownAmount;
		gotoIdle();
		gotoLeftCooldown = -1;
	}
	
	public void releaseRight () {
		gotoIdle();
	}

	void gotoIdle () {
		mySprite.sprite = idleSprite;
		leftArm.GetComponent<BoxCollider2D>().enabled = false;
		rightArm.GetComponent<BoxCollider2D>().enabled = false;
	}

	void gotoLeft () {
		mySprite.sprite = leftSprite;
		leftArm.GetComponent<BoxCollider2D>().enabled = true;
	}

	void gotoRight () {
		mySprite.sprite = rightSprite;
		rightArm.GetComponent<BoxCollider2D>().enabled = true;
	}

	public void hitLeftArm(Collider2D collider) {
		Debug.Log (collider.name);
		Destroy (collider.gameObject);
	}

	public void hitRightArm(Collider2D collider) {
		Debug.Log (collider.name);
		Destroy (collider.gameObject);
	}
}
