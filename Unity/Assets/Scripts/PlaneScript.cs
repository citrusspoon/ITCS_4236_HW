using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{

	public GameObject character;
	private GameObject obstacleClone;
	public GameObject obstaclePrefab;



	// Use this for initialization
	void Start ()
	{

	}
	/// <summary>
	/// Sets the target point for Kinematic Arrive
	/// </summary>
	void leftClick ()
	{
		//sends mouse click position to the KinematicArrive script
		character.GetComponent<KinematicArrive> ().setTarget (Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x,
			Input.mousePosition.y, Camera.main.nearClipPlane)));
	}
	/// <summary>
	/// Creates an obstacle at clicked point.
	/// </summary>
	void rightClick ()
	{
		Vector3 clickPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
		obstacleClone = Instantiate (obstaclePrefab, new Vector3(clickPoint.x, clickPoint.y, 0.0f) , Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetMouseButtonDown (0))
			leftClick ();

		if (Input.GetMouseButtonDown (1))
			rightClick ();

	}
}
