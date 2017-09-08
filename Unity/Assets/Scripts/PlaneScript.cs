using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{

	public GameObject character;


	// Use this for initialization
	void Start ()
	{

	}

	void OnMouseDown ()
	{

		//sends mouse click position to the KinematicArrive script
		character.GetComponent<KinematicArrive> ().setTarget (Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x,
			Input.mousePosition.y, Camera.main.nearClipPlane)));

	}
	
	// Update is called once per frame
	void Update ()
	{
		


	}
}
