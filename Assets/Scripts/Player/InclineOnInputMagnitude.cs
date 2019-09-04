using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclineOnInputMagnitude : MonoBehaviour {

	Vector3 targetRotation;

	public float maxIncline;
	public float inclineDamping;

	// Use this for initialization
	void Start () {
		targetRotation = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 inputVector = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0.0f, Input.GetAxisRaw ("Vertical"));
		targetRotation = new Vector3 (0.0f, 0.0f, maxIncline * inputVector.magnitude);
		Vector3 difference = targetRotation - transform.localRotation.eulerAngles;

		// fix overflow
		while (difference.z >= 200f)
			difference.z -= 360f;
		while (difference.z <= -200f)
			difference.z += 360f;
		
		transform.Rotate (inclineDamping * difference);
	}
}
