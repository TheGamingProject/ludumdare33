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
		GameObject.Find ("Score").GetComponent<Score> ().givePoints (deathPoints, deathSeconds);

		// seconds text
		Transform t = TransformFactory.make2dTransform(popupTextPrefab, new Vector2(transform.position.x, transform.position.y), transform);
		t.position = new Vector3 (t.position.x -.5f, t.position.y + 1f, t.position.z - 5f);
		if (t.rotation.y == 1)
			t.Rotate (new Vector3 (0, 180, 0));
		t.GetComponent<TextMesh> ().text = "+" + deathSeconds + "sec";

		// seconds text
		Transform t2 = TransformFactory.make2dTransform(popupTextPrefab, new Vector2(transform.position.x, transform.position.y), transform);
		t2.position = new Vector3 (t2.position.x +.5f, t2.position.y - 1f, t2.position.z - 5f);
		if (t2.rotation.y == 1)
			t2.Rotate (new Vector3 (0, 180, 0));
		t2.GetComponent<TextMesh> ().text = "+" + deathPoints + "pts";
		t2.GetComponent<ScrollingCombatText> ().speed = new Vector2 (.2f, -1f);
	}
}
