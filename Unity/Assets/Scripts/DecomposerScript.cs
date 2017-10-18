using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DecomposerScript : MonoBehaviour {

	public int planeLength, planeHeight;
	public GameObject plane;
	public Node[,] grid;

	// Use this for initialization
	void Start () {
		grid = new Node[50,50];
		for (int i = 0; i < planeLength; i++)
			for (int j = 0; j < planeHeight; j++)
				grid [i, j] = new Node (i,j,true);
			
	
	}
	/*
	void drawLines(){
		for (int i = 0; i < planeLength; i++) {
			for (int j = 0; j < planeHeight; j++) {
				if(grid[i,j].isPathable())
					Debug.DrawLine (new Vector3 (i + 0.5f, j + 0.5f, -2), new Vector3 (i + 0.5f, j + 0.5f, 1), Color.green);
				else
					Debug.DrawLine (new Vector3 (i + 0.5f, j + 0.5f, -2), new Vector3 (i + 0.5f, j + 0.5f, 1), Color.blue);
			}
		}
	}



	void decompose(){

		RaycastHit hit;

		for (int i = 0; i < planeLength; i++) {
			for (int j = 0; j < planeHeight; j++) {

				if (Physics.Raycast (new Vector3 (i + 0.5f, j + 0.5f, -2), new Vector3 (i + 0.5f, j + 0.5f, 1), out hit)) {
					if (hit.collider.gameObject.tag == "Obstacle") {
						grid [i, j] = new Node (false);
						print ("Unpathable found at: " + i + "," + j);
					} else {
						grid [i, j] = new Node (true);
					}
				}
				else
					grid [i, j] = new Node (true);

			}
		}
				
		print ("Decompose finished");

		

	}
	*/
	void drawLines(){
		for (int i = 0; i < planeLength; i++) {
			for (int j = 0; j < planeHeight; j++) {
				if(grid[i,j].isPathable())
					Debug.DrawLine (new Vector3 (i + 0.5f, j + 0.5f, -2), new Vector3 (i + 0.5f, j + 0.5f, 1), Color.green);
				else
					Debug.DrawLine (new Vector3 (i + 0.5f, j + 0.5f, -2), new Vector3 (i + 0.5f, j + 0.5f, 1), Color.blue);
			}
		}
	}

	void decompose(){

		for(int i = 0; i < plane.GetComponent<PlaneScript>().obstacleList.Count; i++){

			int currentObstacleX = (int)plane.GetComponent<PlaneScript> ().obstacleList [i].transform.position.x;
			int currentObstacleY =(int) plane.GetComponent<PlaneScript> ().obstacleList [i].transform.position.y;
		
			if (grid [currentObstacleX, currentObstacleY].isPathable ())
				grid [currentObstacleX, currentObstacleY].setPathable (false);


		}
		print ("Decompose finished");
	}
		

	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
			decompose ();

		if(Input.GetKey(KeyCode.LeftControl))
			drawLines ();


	}
}
