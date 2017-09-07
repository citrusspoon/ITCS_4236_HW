using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrive : MonoBehaviour {

	public GameObject character;
	public float maxSpeed;
	private Vector3 target;
	public float satRadius;
	public float timeToTarget;
	private bool enRoute;

	// Use this for initialization
	void Start () {
		enRoute = false;
	}
		
	/// <summary>
	/// Teleports to point. Used for testing
	/// </summary>
	/// <param name="t">T.</param>

	public void teleportToPoint(Vector3 t){

		target = new Vector3 (t.x, t.y, -1.0f);

		character.transform.position = target;
		print (target);
	}

	/// <summary>
	/// Moves to point with rotation.
	/// </summary>
	/// <param name="t">T.</param>
	public void moveToPoint(Vector3 t){
		target = new Vector3 (t.x, t.y, -1.0f);
		enRoute = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (enRoute) {

			Vector3 direction = target - character.transform.position;
			float rotateZ = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			//character.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotateZ);
			//print (direction);
			character.transform.rotation = Quaternion.Lerp (character.transform.rotation, Quaternion.Euler(0.0f, 0.0f, rotateZ), Time.deltaTime*5.0f);
			//character.transform.LookAt(target);




			if (direction.magnitude > maxSpeed) {
				direction.Normalize ();
				direction *= maxSpeed;
			}

			character.GetComponent<Rigidbody> ().velocity = direction;

		}
	}
}
