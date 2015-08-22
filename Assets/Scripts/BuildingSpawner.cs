using UnityEngine;
using System.Collections.Generic;

public class BuildingSpawner : MonoBehaviour {
	public Transform spawneePrefab;
	
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
			spawn (true);
			Debug.Log ("spawning left");
			spawnLeftCooldown.setCooldownAmount (RandomN.getRandomFloatByRange (spawnRate));
			spawnLeftCooldown.startCooldown ();
		}
		if (spawnRightCooldown.didCooldownExpire()) {
			spawn (false);
			Debug.Log ("spawning right");
			spawnRightCooldown.setCooldownAmount (RandomN.getRandomFloatByRange (spawnRate));
			spawnRightCooldown.startCooldown ();
		}
	}
	
	private void spawn (bool isLeft) {
		float x = (isLeft ? -1 : 1) * spawnXRange;
		Transform t = TransformFactory.make2dTransform(spawneePrefab, new Vector2(x, spawnY), transform);

		if (!isLeft) {
			t.Rotate(new Vector3(0,180,0));
		}
	}
	
}