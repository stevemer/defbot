using UnityEngine;
using System;

public class WeaponControl : MonoBehaviour {

	const int READY = 0;
	//const int FORWARD = 1;
	const int SHOOTING = 2;
	int state = READY;
	double counter;
	Vector3 velocity;
	
	void Start () {
		velocity = Vector3.zero;
	}
	
	void VelocityUpdate () {
		transform.Translate (velocity * (float)Time.deltaTime);
		velocity = velocity * (float)(Math.Pow(0.05F,Time.deltaTime));
	}
	
	void Update () {
		VelocityUpdate();
		if (state == READY) {
			if (Input.GetKey(KeyCode.A))
				transform.Rotate (Vector3.down);
			if (Input.GetKey(KeyCode.D))
				transform.Rotate (Vector3.up);
			if (Input.GetKey(KeyCode.W))
				transform.Rotate (Vector3.left);
			if (Input.GetKey(KeyCode.S))
				transform.Rotate (Vector3.right);
			if (Input.GetKey(KeyCode.Q)) {
				velocity += 9f * Vector3.forward;
			}
			if (Input.GetKey(KeyCode.E)) {
				state = SHOOTING;
				counter = 0.90;
			} else {
//				FindObjectOfType("");
			}
		} else if (state == SHOOTING) {
			counter -= Time.deltaTime;
			if (counter <= 0) {
				velocity += Vector3.back * 350f;
				state = READY;
			}
		}
		
	}
}
