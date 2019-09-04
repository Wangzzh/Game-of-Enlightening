using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecter : MonoBehaviour {

	public bool selected;
	public GameObject indicator;
	GameObject indicatorInstance;

	void Start() {
		selected = false;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<OperationZone>()) {
			indicatorInstance = Instantiate (indicator, transform.position, Quaternion.identity);
			selected = true;
		}
	}

	void OnTriggerExit(Collider other) {
		// Being focused
		if (other.gameObject.GetComponent<OperationZone>()) {
			Destroy (indicatorInstance);
			selected = false;
		}
	}
}
