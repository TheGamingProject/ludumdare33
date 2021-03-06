using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Building : MonoBehaviour
{
	public int deathPoints = 1;
	public float deathSeconds = .25f;

	public Transform popupTextPrefab;

	public void die () {
		GetComponent<Animator> ().SetBool ("isDead", true);
		GetComponent<BoxCollider2D> ().enabled = false;
		GameObject.Find ("Score").GetComponent<Score> ().givePoints (deathPoints, deathSeconds);

		int isLeft = transform.rotation.y == 1 ? 1 : -1;

		// seconds text
		Transform t = TransformFactory.make2dTransform(popupTextPrefab, new Vector2(transform.position.x, transform.position.y), transform);
		t.position = new Vector3 (t.position.x -.5f, t.position.y + 1f, t.position.z - 5f);
		if (t.rotation.y == 1)
			t.Rotate (new Vector3 (0, 180, 0));
		t.GetComponent<TextMesh> ().text = "+" + deathSeconds + "sass";
		t.GetComponent<ScrollingCombatText> ().speed = new Vector2 (isLeft * -.2f, 1f);

		// seconds text
		Transform t2 = TransformFactory.make2dTransform(popupTextPrefab, new Vector2(transform.position.x, transform.position.y), transform);
		t2.position = new Vector3 (t2.position.x +.5f, t2.position.y - 1f, t2.position.z - 5f);
		if (t2.rotation.y == 1)
			t2.Rotate (new Vector3 (0, 180, 0));
		t2.GetComponent<TextMesh> ().text = "+" + deathPoints + "pts";
		t2.GetComponent<ScrollingCombatText> ().speed = new Vector2 (isLeft * -.2f, 1f);

		AudioSource hitSound = GetComponent<AudioSource> ();
		if (hitSound != null)
			hitSound.Play ();
	}
}
