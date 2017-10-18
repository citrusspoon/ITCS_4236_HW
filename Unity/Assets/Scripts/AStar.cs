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

		Node top, bottom, left, right;
		List<Node> closedList = new List<Node>();
		List<Node> path = new List<Node>();
		Node currentNode;
		List<Node> openList = new List<Node>();
		bool goalfound = false;

		openList.Add (new Node(0,0,true));
		openList [0].setF (3);
		openList.Add (new Node(1,0,true));
		openList [1].setF (2);
		openList.Add (new Node(2,0,true));
		openList [2].setF (1);

		openList.Sort (delegate(Node x, Node y) {
			return x.getF().CompareTo(y.getF());
		});

		for (int i = 0; i < 3; i++)
			print (openList[i].toString());


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
