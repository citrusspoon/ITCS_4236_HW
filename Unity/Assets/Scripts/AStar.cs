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




	}
	/// <summary>
	/// Returns the Node at the top of the heap, removes it, and re-sorts the heap.
	/// </summary>
	/// <param name="l">Heap object</param>
	private Node poll(List<Node> l){
		Node temp = l [0];
		l.RemoveAt(0);
		l.Sort (delegate(Node x, Node y) {
			return x.getF().CompareTo(y.getF());
		});
		return temp;
	}
	/// <summary>
	/// Returns the Node at the top of the heap, but does not remove it.
	/// </summary>
	/// <param name="l">Heap Object</param>
	private Node peek(List<Node> l){
		return l [0];
	}
	/// <summary>
	/// Adds Node to heap, and sorts it.
	/// </summary>
	/// <param name="n">Node to add</param>
	/// <param name="l">Heap object</param>
	private void addToHeap(Node n, List<Node> l){
		l.Add (n);
		l.Sort (delegate(Node x, Node y) {
			return x.getF().CompareTo(y.getF());
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
