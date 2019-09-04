using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartSceneOnHitLight : MonoBehaviour {

	public CheckpointManager checkpointManager;

	bool bombing;

	public AudioClip deathSound;

	float invincibilityTime;

	void Start() {
		bombing = false;
	}

	void Update() {
		if (invincibilityTime > 0f) {
			invincibilityTime -= Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!bombing && invincibilityTime <= 0f && other.gameObject.GetComponent<LightUnit> ()) {
			StartCoroutine (Bomb ());
			AudioSource.PlayClipAtPoint (deathSound, Camera.main.transform.position);
			bombing = true;
		}
	}

	IEnumerator Bomb() {
		gameObject.GetComponent<InputController> ().enabled = false;
		gameObject.GetComponent<Rigidbody> ().velocity = Vector3.up * 5;
		transform.Find ("Bomb").gameObject.SetActive (true);

		yield return new WaitForSeconds (0.4f);
		gameObject.GetComponent<InputController> ().enabled = true;

		yield return new WaitForSeconds (0.6f);
		transform.Find ("Bomb").gameObject.SetActive (false);
		checkpointManager.RestoreGame ();
		bombing = false;
		invincibilityTime = 2.0f;
	}
}
