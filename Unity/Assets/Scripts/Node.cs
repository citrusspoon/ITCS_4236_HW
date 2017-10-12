using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node {

	private bool pathable;

	public Node(bool b){
		pathable = b;
	}

	public bool isPathable(){
		return pathable;
	}

}
