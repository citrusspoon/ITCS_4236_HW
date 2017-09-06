using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrive : MonoBehaviour {

	public GameObject character;
	private Vector3 target;
	public float maxSpeed;
	public float satRadius;
	public float timeToTarget;

	// Use this for initialization
	void Start () {
		
	}

	void setTarget(Vector3 m){
		target = m;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
