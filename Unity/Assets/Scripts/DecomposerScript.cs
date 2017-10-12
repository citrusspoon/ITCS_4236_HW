using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecomposerScript : MonoBehaviour {

	public int planeLength, planeHeight;
	// Use this for initialization
	void Start () {
		
	}

	void decompose(){

		for(int i = 0; i < planeLength; i++)
			for(int j = 0; j < planeHeight; j++)
				Debug.DrawLine (new Vector3(i + 0.5f,j+0.5f,-2), new Vector3(i + 0.5f,j+0.5f,1), Color.green);


		

	}
	
	// Update is called once per frame
	void Update () {

		decompose ();
	}
}
