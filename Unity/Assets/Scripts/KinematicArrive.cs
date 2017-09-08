using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrive : MonoBehaviour
{

	public GameObject character;
	public float maxSpeed;
	public float rotateSpeed;
	private Vector3 target;
	public float satRadius;
	public float timeToTarget;
	private Vector3 direction;

	// Use this for initialization
	void Start ()
	{
		target = Vector3.zero;
	}

	/// <summary>
	/// Teleports to point. Used for testing
	/// </summary>
	/// <param name="t">T.</param>

	public void teleportToPoint (Vector3 t)
	{

		target = new Vector3 (t.x, t.y, -1.0f);

		character.transform.position = target;
		print (target);
	}

	/// <summary>
	/// Moves to point with rotation.
	/// </summary>
	/// <param name="t">T.</param> 
	public void setTarget (Vector3 t)
	{
		target = new Vector3 (t.x, t.y, -1.0f);

	}

	/// <summary>
	/// Calculates the Vector3 between the character and the target.
	/// </summary>
	private void updateDir ()
	{
		direction = target - character.transform.position;
		float rotateZ = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		character.transform.rotation = Quaternion.Lerp (character.transform.rotation, Quaternion.Euler (0.0f, 0.0f, rotateZ), Time.deltaTime * rotateSpeed);

	}

	/// <summary>
	/// Rotates the character toward the target. Speed can be se in inspector.
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
	
	// Update is called once per frame
	void Update ()
	{

		updateDir ();
		rotate ();
		capSpeed ();

		direction /= timeToTarget;

		character.GetComponent<Rigidbody> ().velocity = direction;


	}
}
