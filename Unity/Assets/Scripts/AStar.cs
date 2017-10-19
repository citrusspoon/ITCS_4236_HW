using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour {

	private Vector3 target;
	private Node goalNode;
	private Node startNode;
	public GameObject decomposer;
	public int planeLength;
	private GameObject markerClone;
	public int planeHeight;
	private bool pathing;
	private List<Vector3> movementPath;
	public GameObject markerPrefab;
	private int movementIndex;
	private float lerpVar;



	// Use this for initialization
	void Start () {
		pathing = false;
		movementIndex = 1;
		lerpVar = 0f;
		movementPath = new List<Vector3> ();
	}

	public void setTarget (Vector3 t){
		print ("Setting target");
		target = new Vector3 ((int)t.x, (int)t.y, 0); //sets the correct z position of the target
		decomposer.GetComponent<DecomposerScript>().decompose();
		print ("printing grid");
		for (int i = 0; i < 50; i++)
			for (int j = 0; j < 50; j++)
				if(!decomposer.GetComponent<DecomposerScript>().grid[i,j].isPathable())
					print (decomposer.GetComponent<DecomposerScript>().grid[i,j].toString());


		

		goalNode = decomposer.GetComponent<DecomposerScript>().grid[(int)target.x, (int)target.y];
		startNode = decomposer.GetComponent<DecomposerScript>().grid[(int)transform.position.x, (int)transform.position.y];
		runAStar ();
	}

	public void runAStar(){
		print ("Start astar");
		Node top, bottom, left, right;
		List<Node> closedList = new List<Node>();
		List<Node> path = new List<Node>();
		Node currentNode;
		List<Node> openList = new List<Node>();
		movementPath.Clear ();
		bool goalfound = false;


		// calculate F,G,H, parent is null of start node
		startNode.setParent(null);
		startNode.setG(calcG(startNode));
		startNode.setH(calcH(startNode));
		startNode.setF();

		// add start node to open list
		addToHeap(startNode, openList);

		print ("Start: " + startNode.toString());
		print ("Goal: " + goalNode.toString());
		// loop while goal is not found or openlist is not empty

		while (!goalfound && openList.Count > 0) {
			// pop off node with lowest F from open list
			currentNode = poll(openList);

			// check if it's the goal node, if yes generate path
			if (currentNode.equals (goalNode)) {
				goalfound = true;
				// generate path
				while (currentNode.getParent () != null) {
					path.Add (currentNode);
					currentNode = currentNode.getParent ();
				}

				//add start node to path
				path.Add (startNode);

				//reverse path here

				for (int i = path.Count - 1; i >= 0; i--) {
					print(path[i].toString());
					movementPath.Add (new Vector3(path[i].getRow(), path[i].getCol(),0));
					markerClone = Instantiate (markerPrefab, new Vector3(path[i].getRow(),path[i].getCol() , 0.0f) , Quaternion.identity) as GameObject;
				}

				pathing = true;


			} else {
				//generate neighbors


				// -------------Top--------------//

				if (currentNode.getRow() - 1 > 0) {
					top = decomposer.GetComponent<DecomposerScript>().grid[currentNode.getRow() - 1,currentNode.getCol()];
					if (top.isPathable() && !closedList.Contains(top)) {
						top.setG(calcG(top));
						top.setH(calcH(top));
						top.setF();
						top.setParent(currentNode);
						addToHeap(top, openList);
					}
				}
				// -------------Bottom--------------//
				if (currentNode.getRow() + 1 < planeHeight - 1) {
					bottom = decomposer.GetComponent<DecomposerScript>().grid[currentNode.getRow() + 1,currentNode.getCol()];
					if (bottom.isPathable() && !closedList.Contains(bottom)) {
						bottom.setG(calcG(bottom));
						bottom.setH(calcH(bottom));
						bottom.setF();
						bottom.setParent(currentNode);
						addToHeap(bottom, openList);
					}
				}
				// -------------Left--------------//
				if (currentNode.getCol() - 1 > 0) {
					left = decomposer.GetComponent<DecomposerScript>().grid[currentNode.getRow(),currentNode.getCol() - 1];
					if (left.isPathable() && !closedList.Contains(left)) {
						left.setG(calcG(left));
						left.setH(calcH(left));
						left.setF();
						left.setParent(currentNode);
						addToHeap(left, openList);
					}
				}
				// -------------Right--------------//
				if (currentNode.getCol() + 1 < planeLength - 1) {
					right = decomposer.GetComponent<DecomposerScript>().grid[currentNode.getRow(),currentNode.getCol() + 1];
					if (right.isPathable() && !closedList.Contains(right)) {
						right.setG(calcG(right));
						right.setH(calcH(right));
						right.setF();
						right.setParent(currentNode);
						addToHeap(right, openList);
					}
				}

				// add current node to closed list
				closedList.Add(currentNode);



			}
		}

		if(!goalfound) {
			print("No path found.");
		}



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

	private int calcH(Node n) {

		return Mathf.Abs(n.getCol() - goalNode.getCol()) + Mathf.Abs(n.getRow() - goalNode.getRow());
	}

	private int calcG(Node n) {

		return Mathf.Abs(n.getCol() - startNode.getCol()) + Mathf.Abs(n.getRow() - startNode.getRow());
	}
	
	// Update is called once per frame
	void Update () {

		if (movementIndex < movementPath.Count) {
			GetComponent<Transform> ().position = Vector3.Lerp (GetComponent<Transform> ().position, movementPath [movementIndex], lerpVar);
			lerpVar += 6f / 50f;

			if (lerpVar >= 1f) {
				lerpVar = 0f;
				movementIndex++;
			}
		}

		if (movementIndex == movementPath.Count) {
			movementPath.Clear ();
			movementIndex = 1;
		}


		
	}
}
