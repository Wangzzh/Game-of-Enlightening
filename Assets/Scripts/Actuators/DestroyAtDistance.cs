using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtDistance : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (transform.position.magnitude >= 50f) {
			Destroy (gameObject);
		}
	}
}
