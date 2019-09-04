using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUnit : MonoBehaviour {

	int NORMAL = 0;
	int SPAWNED = 1;
	int DEAD = 2;

	public int state;

	void Start() {
		state = SPAWNED;
		StartCoroutine (Spawn ());
	}

	public void kill() {
		if (state == NORMAL) {
			state = DEAD;
			StartCoroutine (Kill ());
		}
	}

	public bool isNormal() {
		return state == NORMAL;
	}

	IEnumerator Spawn() {
		yield return new WaitForSeconds (0.08f);
		state = NORMAL;
	}

	IEnumerator Kill() {
		yield return new WaitForSeconds (0.02f);
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		yield return new WaitForSeconds (0.3f);
		Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider other) {
		if (isNormal ()) {
			if (other.gameObject.GetComponent<Floor> ()
			    || other.gameObject.GetComponent<Wall> ()
				|| other.gameObject.GetComponent<Gate> ()
				|| other.gameObject.GetComponent<Emitter> ()) {
				StartCoroutine (Kill ());
				transform.Find ("Boom").gameObject.SetActive (true);
			}
		}
	}
}
