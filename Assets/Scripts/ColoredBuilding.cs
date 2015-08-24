using UnityEngine;
using System.Collections;

public class ColoredBuilding : Building
{
	public Colors color;

	public Transform greenPeoplePrefab;
	public Transform purplePeoplePrefab;
	public Vector2 greenPeopleOffset;
	public Vector2 purplePeopleOffset;

	public new void die() {
		base.die ();
		GameObject.Find("MultiplierManager").GetComponent<MultiplierManager>().hitColoredBuilding(color);

		
		Transform prefab;
		float spawnX, spawnY;
		float spawnX2, spawnY2;
		if (Random.value > .5) {
			prefab = greenPeoplePrefab;
			spawnX = transform.position.x + greenPeopleOffset.x;
			spawnY = transform.position.y + greenPeopleOffset.y;
			spawnX2 = transform.position.x + greenPeopleOffset.x;
			spawnY2 = transform.position.y - greenPeopleOffset.y;
		} else {
			prefab = purplePeoplePrefab;
			spawnX = transform.position.x + purplePeopleOffset.x;
			spawnY = transform.position.y + purplePeopleOffset.y;
			spawnX2 = transform.position.x + purplePeopleOffset.x;
			spawnY2 = transform.position.y - purplePeopleOffset.y;
		}
		
		TransformFactory.make2dTransform(prefab, new Vector2(spawnX, spawnY), transform);
		Transform t2 = TransformFactory.make2dTransform(prefab, new Vector2(spawnX2, spawnY2), transform);
		t2.position = new Vector3 (t2.position.x, t2.position.y, t2.position.z - .1f);
		t2.Rotate (new Vector3 (0, 180, 180));


		// up sass count for end screen
		ScorePasser sp = GameObject.Find ("ScorePasser").GetComponent<ScorePasser>();

		switch (color) {
		case Colors.Blue:
				sp.upOneBlue();
			break;
		case Colors.Red:
			sp.upOneRed();
			break;
		case Colors.Orange:
			sp.upOneOrange();
			break;
		case Colors.Green:
			sp.upOneGreen();
			break;
		}
	}
}

