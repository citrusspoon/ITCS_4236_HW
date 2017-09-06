using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {




	// Use this for initialization
	void Start () {
		
	}
		
	public Vector3 getMouseLocation(){
		return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
			Input.mousePosition.y, Camera.main.nearClipPlane));
	}
	
	// Update is called once per frame
	void Update () {
		

		// Get the mouse position from Event.
		// Note that the y position from Event is inverted.

	}
}
