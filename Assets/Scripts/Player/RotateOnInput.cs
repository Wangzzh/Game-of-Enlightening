using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnInput : MonoBehaviour {

	Vector3 baseVector = Vector3.up;

	public float rotateDamper;
	Vector3 targetRotation;

	void Start () {
		targetRotation = transform.localRotation.eulerAngles;
	}
		
	void FixedUpdate () {
		
		// Get input vector
		Vector3 inputVector = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0.0f, Input.GetAxisRaw ("Vertical"));
		Quaternion cameraRotation = Camera.main.transform.rotation;
		inputVector = cameraRotation * inputVector;

		if (inputVector.magnitude >= 0.1f) {
			float rotateY = Mathf.Atan (- inputVector.z / inputVector.x) / Mathf.PI * 180f;
			if (inputVector.x < 0.0f) {
				rotateY += 180f;
			}
			targetRotation = new Vector3 (0.0f, rotateY, 0.0f);
		}

		// Fix overflow
		Vector3 difference = targetRotation - transform.localRotation.eulerAngles;
		while (difference.y >= 200f)
			difference.y -= 360f;
		while (difference.y <= -200f)
			difference.y += 360f;

		Vector3 vibrate = new Vector3 (0.0f, Random.value, 0.0f) * 0.0f;

		transform.Rotate (rotateDamper * difference + vibrate);
	}
}
