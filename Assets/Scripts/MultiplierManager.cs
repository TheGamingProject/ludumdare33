using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MultiplierManager : MonoBehaviour
{
	public Sprite blueIndicator;
	public Sprite blueIndicatorChecked;
	public Sprite greenIndicator;
	public Sprite greenIndicatorChecked;
	public Sprite redIndicator;
	public Sprite redIndicatorChecked;
	public Sprite orangeIndicator;
	public Sprite orangeIndicatorChecked;


	List<Transform> boxes = new List<Transform> ();

	Dictionary<Colors, Sprite> colorIndicators = new Dictionary<Colors, Sprite>();
	Dictionary<Colors, Sprite> colorIndicatorsChecked = new Dictionary<Colors, Sprite>();


	// Use this for initialization
	void Start ()
	{
		boxes.Add(transform.GetChild (0));
		boxes.Add(transform.GetChild (1));
		boxes.Add( transform.GetChild (2));
		boxes.Add(transform.GetChild (3));
		boxes.Add(transform.GetChild (4));


		colorIndicators.Add (Colors.Blue, blueIndicator);
		colorIndicators.Add (Colors.Green, greenIndicator);
		colorIndicators.Add (Colors.Orange, orangeIndicator);
		colorIndicators.Add (Colors.Red, redIndicator);
		colorIndicatorsChecked.Add (Colors.Blue, blueIndicatorChecked);
		colorIndicatorsChecked.Add (Colors.Green, greenIndicatorChecked);
		colorIndicatorsChecked.Add (Colors.Orange, orangeIndicatorChecked);
		colorIndicatorsChecked.Add (Colors.Red, redIndicatorChecked);

		disableAll ();
		startMultiplierSet (2);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void startMultiplierSet(int amount) {
		List<Colors> colors = new List<Colors>();
		for (int i=0; i<amount; i++) {
			colors.Add((Colors)Random.Range(0,4));
		}
		for (int i=0; i<amount; i++) {
			boxes[i].GetComponent<Image>().enabled = true;
			boxes[i].GetComponent<Image>().sprite = colorIndicators[colors[i]];
		}
	}

	public void hitColoredBuilding (Colors color) {

	}

	void enable2() {
		boxes[0].GetComponent<Image> ().enabled = true;
		boxes[1].GetComponent<Image> ().enabled = true;
	}

	void disableAll () {
		boxes[0].GetComponent<Image> ().enabled = false;
		boxes[1].GetComponent<Image> ().enabled = false;
		boxes[2].GetComponent<Image> ().enabled = false;
		boxes[3].GetComponent<Image> ().enabled = false;
		boxes[4].GetComponent<Image> ().enabled = false;
	}
}

