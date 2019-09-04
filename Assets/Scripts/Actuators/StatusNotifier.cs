using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusNotifier : MonoBehaviour {

	public Text statusTextObject;
	public string statusText;

	bool displayed;

	void Start() {
		displayed = false;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Player> ()) {
			if (!displayed) {
				displayed = true;
				statusTextObject.GetComponent<OneTimeBlinker> ().Blink (statusText);
			}
		}
	}
		
}
