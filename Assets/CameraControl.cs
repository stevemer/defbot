using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
			transform.Rotate (Vector3.down);
		if (Input.GetKey(KeyCode.D))
			transform.Rotate (Vector3.up);
		if (Input.GetKey(KeyCode.W))
			transform.Rotate (Vector3.left);
		if (Input.GetKey(KeyCode.S))
			transform.Rotate (Vector3.right);
	}
}
