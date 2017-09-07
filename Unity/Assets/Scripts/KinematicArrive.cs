using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrive : MonoBehaviour {

	public GameObject character;
	public float maxSpeed;
	public float satRadius;
	public float timeToTarget;

	// Use this for initialization
	void Start () {
		
	}
		

	public void moveToPoint(Vector3 target){

		character.transform.position = new Vector3(target.x, target.y, -1.0f);
		print (target);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
