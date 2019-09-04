using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCameraRotator : MonoBehaviour {

	bool waiting;

	void Start() {
		waiting = true;
	}

	void Update() {
		if (Input.GetAxisRaw ("Rotate") > 0f) {
			if (waiting) {
				waiting = false;
				transform.Rotate (Vector3.up * 45);
			}
		} else if (Input.GetAxisRaw ("Rotate") < 0f) {
			if (waiting) {
				waiting = false;
				transform.Rotate (Vector3.down * 45);
			}
		} else {
			waiting = true;
		}
				
	}
}
