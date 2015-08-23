using UnityEngine;
using System.Collections.Generic;

public class CarSpawner : MonoBehaviour {
	public Transform carPrefab;
	public Transform carPrefab2;
	
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
		Transform prefab;

		if (Random.value > .5) {
			prefab = carPrefab;
		} else {
			prefab = carPrefab2;
		}

		Transform t = TransformFactory.make2dTransform(prefab, new Vector2(spawnX, spawnY), transform);
	}
	
}
