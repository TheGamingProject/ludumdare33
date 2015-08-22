using System;
using UnityEngine;

public class Cooldown{
	float cooldownAmount;

	float startTime;

	public Cooldown (float cooldownAmount) {
		this.cooldownAmount = cooldownAmount;
		this.stopCooldown ();
	}

	public void startCooldown () {
		startTime = Time.timeSinceLevelLoad;
	}

	public void stopCooldown () {
		startTime = -1;
	}

	public void setCooldownAmount (float amount) {
		this.cooldownAmount = amount;
	}

	public bool isCooldownActive () {
		return startTime > -0.001;
	}

	public bool didCooldownExpire () {
		return isCooldownActive() && startTime + cooldownAmount < Time.timeSinceLevelLoad;
	}

	public float getTimeLeft () {
		if (startTime == -1)
			return -1;

		return (startTime + cooldownAmount) - Time.timeSinceLevelLoad;
	}

	public void addTime (float amount) {
		startTime += amount;
	}
}

