using UnityEngine;
using System;

public class VelocityControl : MonoBehaviour {
	public Vector3 velocity;
	const float AIR_RESISTANCE = 0.05F;
	
	void Start () {
		velocity = Vector3.zero;
	}
	
	void Update () {
		transform.Translate(velocity * (float)Time.deltaTime);
		velocity *= (float)(Math.Pow(AIR_RESISTANCE,Time.deltaTime));
	}
}
