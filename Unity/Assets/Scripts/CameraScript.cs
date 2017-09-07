using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject character;


	// Use this for initialization
	void Start () {

	}
		
	void OnMouseDown(){
		character.GetComponent<KinematicArrive>().moveToPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
			Input.mousePosition.y, Camera.main.nearClipPlane)));
		Debug.DrawRay (Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x,
			Input.mousePosition.y, Camera.main.nearClipPlane)),Camera.main.transform.forward*1000, Color.green);

	}
	
	// Update is called once per frame
	void Update () {
		

		// Get the mouse position from Event.
		// Note that the y position from Event is inverted.

	}
}
