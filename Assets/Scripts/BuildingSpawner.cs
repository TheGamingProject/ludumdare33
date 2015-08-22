using UnityEngine;
using System.Collections.Generic;

public class BuildingSpawner : MonoBehaviour {
	public Transform spawneePrefab1;
	public Transform spawneePrefab2;
	public Transform spawneePrefab3;
	public Transform spawneePrefab4;
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
	
	void Start () {
		spawnLeftCooldown = new Cooldown(initialSpawnTime);
		spawnLeftCooldown.startCooldown();
		spawnRightCooldown = new Cooldown(initialSpawnTime);
		spawnRightCooldown.startCooldown();
	}
	
	void Update () {
		if (spawnLeftCooldown.didCooldownExpire()) {
			float extraSpawnTime = spawn (true);
			//.Log ("spawning left");
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
	
	private float spawn (bool isLeft) {
		float x = (isLeft ? -1 : 1) * spawnXRange;
		float yOffset = 0;
		float extraWaitTime = .0f;

		Transform buildingPrefab = null;
		int whichBuilding = Random.Range (0, 6);
		switch (whichBuilding) {
		case 0:
			buildingPrefab = spawneePrefab1;
			break;
		case 1:
			buildingPrefab = spawneePrefab2;
			break;
		case 2:
			buildingPrefab = spawneePrefab3;
			break;
		case 3:
			buildingPrefab = spawneePrefab4;
			break;
		case 4:
			buildingPrefab = safeGroup1Prefab;
			x += (isLeft ? -1 : 1) * group1XOffset;
			yOffset = 1;
			extraWaitTime = .5f;
			break;
		case 5:
			buildingPrefab = safeGroup2Prefab;
			x += (isLeft ? -1 : 1) * group2XOffset;
			yOffset = 1;
			extraWaitTime = .5f;
			break;
		}


		Transform t = TransformFactory.make2dTransform(buildingPrefab, new Vector2(x, spawnY - yOffset), transform);

		if (!isLeft) {
			t.Rotate(new Vector3(0,180,0));
		}

		return extraWaitTime;
	}
	
}