using UnityEngine;
using System.Collections.Generic;

public class CarSpawner : MonoBehaviour {
	public Transform carPrefab;
	
	public float spawnX = -5.33f;
	public float spawnY = 30.4f;

	public Vector2 spawnRate = new Vector2(.1f, 5f);


	Cooldown spawnCooldown;

	void Start () {
		spawnCooldown = new Cooldown (RandomN.getRandomFloatByRange(spawnRate));
		spawnCooldown.startCooldown ();
	}
	
	void Update () {
		if (spawnCooldown.didCooldownExpire()) {
			spawnCooldown.setCooldownAmount(RandomN.getRandomFloatByRange(spawnRate));
			spawn ();
			spawnCooldown.startCooldown ();
		}
	}

	void spawn() {
		Transform t = TransformFactory.make2dTransform(carPrefab, new Vector2(spawnX, spawnY), transform);
	}
	
}
