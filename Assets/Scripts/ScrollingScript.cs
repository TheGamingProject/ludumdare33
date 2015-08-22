// Based off http://pixelnest.io/tutorials/2d-game-unity/install-and-scene/
// need RendererExtensions too

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ScrollingScript : MonoBehaviour
{
	/// <summary>
	/// Scrolling speed
	/// </summary>
	//public Vector2 speed = new Vector2(10, 10);
	
	/// <summary>
	/// Movement should be applied to camera
	/// </summary>
	public bool isLinkedToCamera = false;
	
	/// <summary>
	/// 1 - Background is infinite
	/// </summary>
	public bool isLooping = false;
	
	/// <summary>
	/// 2 - List of children with a renderer.
	/// </summary>
	private List<Transform> backgroundPart;
	
	// 3 - Get all the children
	void Start()
	{
		// For infinite background only
		if (isLooping)
		{
			// Get all the children of the layer with a renderer
			backgroundPart = new List<Transform>();
			
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				
				// Add only the visible children
				if (child.GetComponent<Renderer>() != null)
				{
					backgroundPart.Add(child);
				}
			}
			
			// Sort by position.
			// Note: Get the children from left to right.
			// We would need to add a few conditions to handle
			// all the possible scrolling directions.
			backgroundPart = backgroundPart.OrderBy(
				t => 1 * t.position.y
				).ToList();
			Debug.Log (backgroundPart[0].name);
		}
	}
	
	void Update()
	{
		// Movement
		Vector3 movement = new Vector3(
			0,
			transform.parent.GetComponent<LevelSpeed>().Speed,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
		
		// Move the camera
		if (isLinkedToCamera)
		{
			Camera.main.transform.Translate(movement);
		}
		//Debug.Log (backgroundPart[0].name + " " + backgroundPart[1].name);
		
		// 4 - Loop
		if (isLooping)
		{
			// Get the first object.
			// The list is ordered from left (x position) to right.
			Transform firstChild = backgroundPart.FirstOrDefault();
			if (firstChild != null)
			{
				//Debug.Log (firstChild.position.y + " < " + Camera.main.transform.position.y);
				// Check if the child is already (partly) before the camera.
				// We test the position first because the IsVisibleFrom
				// method is a bit heavier to execute.
				//Debug.Log( firstChild.name);
				//Debug.Log (firstChild.position.y + "  "	 + Camera.main.transform.position.y);
				if (firstChild.position.y + 30 < Camera.main.transform.position.y)
				{
					Transform lastChild = backgroundPart.LastOrDefault();
					Vector3 lastPosition = lastChild.transform.position;
					firstChild.transform.position = new Vector3(firstChild.position.x, lastPosition.y + 17, firstChild.position.z); 
					backgroundPart.Remove(firstChild);
					backgroundPart.Add(firstChild);
				}
			}
		}
	}
}