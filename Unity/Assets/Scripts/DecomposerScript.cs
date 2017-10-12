using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecomposerScript : MonoBehaviour {

	public int planeLength, planeHeight;
	// Use this for initialization
	void Start () {
		
	}

	void decompose(){


		Debug.DrawLine (new Vector3(0,0,-2), new Vector3(0,0,1), Color.green);

		

	}
	
	// Update is called once per frame
	void Update () {

		decompose ();
	}
}
