using UnityEngine;
using System.Collections.Generic;

public class BuildingSpawner : MonoBehaviour {
	public Transform bluePrefab;
	public Transform greenPrefab;
	public Transform redPrefab;
	public Transform orangePrefab;
	Dictionary<Colors,Transform> colorPrefabs = new Dictionary<Colors,Transform>();

	public Transform safeGroup1Prefab;
	public Transform safeGroup2Prefab;

	public float group1XOffset = 2f;
	public float group2XOffset = 2f;
	
	public bool scaleWithLevelSpeed = false;
	
	public float initialSpawnTime = 5.0f;
	private Cooldown spawnLeftCooldown;
	private Cooldown spawnRightCooldown;
	
	public float spawnXRange = 3.25f; // from the center
	public float spawnY = -20f;
	
	public Vector2 spawnRate = new Vector2(.5f, 1f);

	float minimumDistance = 10f;
	Transform lastLeftSpawned, lastRightSpawned;

	void Start () {
		spawnLeftCooldown = new Cooldown(initialSpawnTime);
		spawnLeftCooldown.startCooldown();
		spawnRightCooldown = new Cooldown(initialSpawnTime);
		spawnRightCooldown.startCooldown();

		colorPrefabs.Add (Colors.Blue, bluePrefab);
		colorPrefabs.Add (Colors.Green, greenPrefab);
		colorPrefabs.Add (Colors.Red, redPrefab);
		colorPrefabs.Add (Colors.Orange, orangePrefab);
	}
	
	void Update () {
		if (spawnLeftCooldown.didCooldownExpire() && (lastLeftSpawned == null || isTransformDistanceAway(lastLeftSpawned))) {
			float extraSpawnTime = spawn (true);
			if (lastLeftSpawned != null) 
				Debug.Log ("spawning left" + Mathf.Abs (lastLeftSpawned.position.y - transform.position.y));
			spawnLeftCooldown.setCooldownAmount (RandomN.getRandomFloatByRange (spawnRate) + extraSpawnTime);
			spawnLeftCooldown.startCooldown ();
		}
		if (spawnRightCooldown.didCooldownExpire()) {
			float extraSpawnTime = spawn (false);
			//Debug.Log ("spawning right");
			spawnRightCooldown.setCooldownAmount (RandomN.getRandomFloatByRange (spawnRate) + extraSpawnTime);
			spawnRightCooldown.startCooldown ();
		}
	}

	bool isTransformDistanceAway(Transform t) {
		return 10 < Mathf.Abs (t.position.y - transform.position.y);
	}
	
	private float spawn (bool isLeft) {
		float x = (isLeft ? -1 : 1) * spawnXRange;
		float yOffset = 0;
		float extraWaitTime = .0f;

		Transform buildingPrefab = null;
		int whichBuilding = Random.Range (0, 9);
		switch (whichBuilding) {
		case 0:
				buildingPrefab = bluePrefab;
			break;
		case 1:
			buildingPrefab = greenPrefab;
			break;
		case 2:
			buildingPrefab = redPrefab;
			break;
		case 3:
			buildingPrefab = orangePrefab;
			break;
		case 4:
		case 5:
			buildingPrefab = safeGroup1Prefab;
			x += (isLeft ? -1 : 1) * group1XOffset;
			yOffset = 1;
			extraWaitTime = .5f;
			break;
		case 6:
		case 7:
			buildingPrefab = safeGroup2Prefab;
			x += (isLeft ? -1 : 1) * group2XOffset;
			yOffset = 1;
			extraWaitTime = .5f;
			break;
		case 8:
			Colors currentColor = GameObject.Find("MultiplierManager").GetComponent<MultiplierManager>().getColorNeeded();
			buildingPrefab = colorPrefabs[currentColor];
			break;
		}


		Transform t = TransformFactory.make2dTransform(buildingPrefab, new Vector2(x, spawnY - yOffset), transform);

		if (!isLeft) {
			t.Rotate(new Vector3(0,180,0));
			lastRightSpawned = t;
		} else {
			lastLeftSpawned = t;
		}

		return extraWaitTime;
	}
	
}