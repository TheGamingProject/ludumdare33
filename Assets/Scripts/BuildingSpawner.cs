using UnityEngine;
using System.Collections.Generic;

public class BuildingSpawner : MonoBehaviour {
	public Transform spawneePrefab;
	
	public bool scaleWithLevelSpeed = false;
	private LevelSpeed levelSpeed;
	
	public float initialSpawnTime = 5.0f;
	private Cooldown spawnCooldown;
	
	public float spawnXRange = 3.25f; // from the center
	public float spawnY = -20f;
	
	public Vector2 spawnRate = new Vector2(.5f, 1f);
	
	void Start () {
		spawnCooldown = new Cooldown(initialSpawnTime);
		spawnCooldown.startCooldown();
		levelSpeed = transform.GetComponent<LevelSpeed>();
	}
	
	void Update () {
		if (CanSpawn) {
			spawn ();
			Debug.Log ("spawning");
			spawnCooldown.setCooldownAmount (RandomN.getRandomFloatByRange (spawnRate));
			spawnCooldown.startCooldown ();
			
			if (scaleWithLevelSpeed) {
				//Debug.Log (spawneePrefab.name + " " + spawnCooldown + " " + levelSpeed.NonPlayerSpeedRatio + " = " + (spawnCooldown / levelSpeed.NonPlayerSpeedRatio));
				//spawnCooldown /= levelSpeed.NonPlayerSpeedRatio;
			}
		}
	}
	
	private void spawn () {
		bool isLeft = Random.value > .5;
		float x = (isLeft ? -1 : 1) * spawnXRange;
		Transform t = TransformFactory.make2dTransform(spawneePrefab, new Vector2(x, spawnY), transform);

		if (!isLeft) {
			t.Rotate(new Vector3(0,180,0));
		}
	}
	
	public bool CanSpawn {
		get{
			return spawnCooldown.didCooldownExpire();
		}
	}
	
	public void StopSpawning () {
		spawnCooldown.stopCooldown();
	}
	
}