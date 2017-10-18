using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour {

	private Vector3 target;
	private Node goalNode;
	private Node startNode;
	public GameObject decomposer;

	// Use this for initialization
	void Start () {
		
	}

	public void setTarget (Vector3 t){
		target = new Vector3 ((int)t.x, (int)t.y, 0); //sets the correct z position of the target
		decomposer.GetComponent<DecomposerScript>().decompose();
		goalNode = decomposer.GetComponent<DecomposerScript>().grid[(int)target.x, (int)target.y];
		startNode = decomposer.GetComponent<DecomposerScript>().grid[(int)transform.position.x, (int)transform.position.y];
		runAStar ();
	}

	public void runAStar(){




	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
