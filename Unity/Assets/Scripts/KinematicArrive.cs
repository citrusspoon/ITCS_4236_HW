﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrive : MonoBehaviour
{

	public GameObject character;
	public float maxSpeed;
	public float rotateSpeed;
	private Vector3 target;
	public GameObject targetObject;
	public float satRadius;
	public float timeToTarget;
	private Vector3 direction;
	public GameObject cone;

	// Use this for initialization
	void Start ()
	{
		if (targetObject != null) {
			setTarget(targetObject.transform.position);
		} else {
			target = Vector3.zero;
		}
	}

	/// <summary>
	/// Teleports to point. Used for testing
	/// </summary>
	/// <param name="t">T.</param>

	public void teleportToPoint (Vector3 t)
	{

		target = new Vector3 (t.x, t.y, 0.0f); //sets the correct z position of the target

		character.transform.position = target;
		print (target);
	}


	/// <summary>
	/// Moves to point with rotation.
	/// </summary>
	/// <param name="t">T.</param> 
	public void setTarget (Vector3 t)
	{
		target = new Vector3 (t.x, t.y, 0.0f); //sets the correct z position of the target
		updateDir ();

	}

	/// <summary>
	/// Calculates the Vector3 between the character and the target.
	/// </summary>
	private void updateDir ()
	{
		direction = target - character.transform.position; //gets Vector3 between character and target
		float rotateZ = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg; //calculates the change in rotation necessary to face the target in degrees
		character.transform.rotation = Quaternion.Lerp (character.transform.rotation, Quaternion.Euler (0.0f, 0.0f, rotateZ), Time.deltaTime * rotateSpeed); //smoothly rotates character to face target
		//direction /= timeToTarget;

	}
		

	/// <summary>
	/// Rotates the character toward the target. Speed can be set in inspector.
	/// </summary>
	private void rotate ()
	{
		float rotateZ = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		character.transform.rotation = Quaternion.Lerp (character.transform.rotation, Quaternion.Euler (0.0f, 0.0f, rotateZ), Time.deltaTime * rotateSpeed);
	}

	/// <summary>
	/// Prevents character from exceeding maxSpeed.
	/// </summary>
	private void capSpeed ()
	{
		if (direction.magnitude > maxSpeed) {
			direction.Normalize ();
			direction *= maxSpeed;
		}

	}

	/// <summary>
	/// Checks to see if the character is whithin the radius of satisfaction. True indicates that it is.
	/// </summary>
	private bool checkRadius ()
	{
		return direction.magnitude < satRadius;
	}
	
	// Update is called once per frame
	void Update ()
	{

		Debug.DrawRay (transform.position,  direction, Color.green);

		if (targetObject != null) 
			setTarget(targetObject.transform.position);

		if (!checkRadius ()) {
			updateDir ();
			rotate ();
			direction /= timeToTarget;
			capSpeed ();
			character.GetComponent<Rigidbody> ().velocity = direction;
		} else { //stops the character after the radius of satisfaction has been crossed
			character.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}



	}
}
