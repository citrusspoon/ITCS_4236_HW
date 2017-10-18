using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node {

	private bool pathable;
	private int row, col, f, g, h;
	private Node parent;

	public Node(int r, int c, bool t){
		row = r;
		col = c;
		pathable = t;
		parent = null;
	
	}






	//mutator methods to set values
	public void setF(){
		f = g + h;
	}
	public void setF(int x){
		f = x;
	}
	public void setG(int value){
		g = value;
	}
	public void setH(int value){
		h = value;
	}

	public void setParent(Node n){
		parent = n;
	}

	public bool isPathable(){
		return pathable;
	}

	public void setPathable(bool b){
		pathable = b;
	}

	//accessor methods to get values
	public int getF(){
		return f;
	}
	public int getG(){
		return g;
	}
	public int getH(){
		return h;
	}
	public Node getParent(){
		return parent;
	}
	public int getRow(){
		return row;
	}
	public int getCol(){
		return col;
	}



	public bool equals(Node n){
		//typecast to Node

		return row == n.getRow() && col == n.getCol();
	}

	public string toString(){
		return "Node: " + row + "_" + col + "  " + pathable;
	}




}
