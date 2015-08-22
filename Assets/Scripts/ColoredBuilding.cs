using UnityEngine;
using System.Collections;

public class ColoredBuilding : Building
{
	public Colors color;

	public new void die() {
		base.die ();
		GameObject.Find("MultiplierManager").GetComponent<MultiplierManager>().hitColoredBuilding(color);
	}
}

