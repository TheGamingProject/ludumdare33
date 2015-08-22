using System;
using UnityEngine;

public class Cooldown{
	float cooldownAmount;

	float startTime;

	public Cooldown (float cooldownAmount) {
		this.cooldownAmount = cooldownAmount;
	}

	public void startCooldown () {
		startTime = Time.timeSinceLevelLoad;
	}

	public void stopCooldown () {
		startTime = -1;
	}

	public bool isCooldownActive () {
		return startTime > 0;
	}

	public bool didCooldownExpire () {
		return isCooldownActive() && startTime + cooldownAmount < Time.timeSinceLevelLoad;
	}
}

