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
	}

	void Update()
	{
	}

	public void hitDirection(float dir) {
		//Debug.Log ("hit" + direction);
		direction = dir;

		if (direction == -1) {
			mySprite.sprite = leftSprite;
			leftArm.GetComponent<BoxCollider2D>().enabled = true;
		} else if (direction == 1) {
			mySprite.sprite = rightSprite;
			rightArm.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
	
	public void release() {
		mySprite.sprite = idleSprite;
		leftArm.GetComponent<BoxCollider2D>().enabled = false;
		rightArm.GetComponent<BoxCollider2D>().enabled = false;
	}

	public void hitLeftArm(Collider2D collider) {
		Debug.Log (collider.name);
	}

	public void hitRightArm(Collider2D collider) {
		Debug.Log (collider.name);
	}
}
