using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNotifier : MonoBehaviour {

	bool prompting;
	bool inrange;

	public Text prompter;
	public string promptText;

	public float delayTime;

	float cumulativeTime;

	// Use this for initialization
	void Start () {
		prompting = false;
		inrange = false;
	}

	void Update() {
		if (inrange) {
			if (cumulativeTime <= delayTime) {
				cumulativeTime += Time.deltaTime;
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.GetComponent<Player> ()) {
			inrange = true;
			if (!prompting && cumulativeTime >= delayTime) {
				prompter.text = promptText;
				prompting = true;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.GetComponent<Player> ()) {
			prompter.text = "";
			prompting = false;
			inrange = false;
		}
	}
}
