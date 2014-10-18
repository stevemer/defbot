using UnityEngine;
using System;

public class WeaponControl : MonoBehaviour {

	const int READY = 0;
	//const int FORWARD = 1;
	const int SHOOTING = 2;
	
	int state;
	double counter;
	VelocityControl character;
	
	const float FORWARD_ACCELERATION = 1f;
	const float SHOT_RECOIL = 30f;
	
	void Start () {
		state = READY;
		character = transform.parent.GetComponent<VelocityControl>();
	}
	
	void VelocityUpdate (float f) {
		Vector3 unitVector = transform.rotation * Vector3.forward;
		character.velocity += f * unitVector;
	}
	
	void Update () {
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
				VelocityUpdate ((float)Math.Pow(FORWARD_ACCELERATION,Time.deltaTime));
				//Debug.Log (transform.localEulerAngles*(float)Math.Pow(FORWARD_ACCELERATION,Time.deltaTime));
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
				VelocityUpdate (-SHOT_RECOIL); //Not using deltaTime because I want impulse to be consistent.
				state = READY;
			}
		}
	}
}
