using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour {

	private Vector3 target;

	// Use this for initialization
	void Start () {
		
	}

	public void setTarget (Vector3 t)
	{
		target = new Vector3 ((int)t.x, (int)t.y, 0); //sets the correct z position of the target

		print (target);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
