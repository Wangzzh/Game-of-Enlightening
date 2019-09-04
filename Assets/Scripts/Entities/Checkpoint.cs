using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public Emitter [] emitters;
	public Emitter [] closeEmitters;
	public CheckpointManager manager;
	int checkpointId;

	public AudioClip checkSound;

	Vector3 playerPosition;
	Quaternion playerRotation;

	Vector3 cameraPosition;
	Quaternion cameraRotation;

	GameObject player;

	bool reached;

	void Awake() {
		reached = false;
	}

	void OnTriggerEnter(Collider other) {
		if (!reached && other.gameObject.GetComponent<Player> ()) {
			//player = other.gameObject;
			//playerPosition = player.transform.position;
			//playerRotation = player.transform.rotation;
			//cameraPosition = Camera.main.transform.position;
			//cameraRotation = Camera.main.transform.rotation;
			manager.UpdateState (checkpointId);
			reached = true;
			AudioSource.PlayClipAtPoint (checkSound, Camera.main.transform.position);
		}
	}

	public void RestoreState() {
		foreach (Emitter emitter in emitters) {
			emitter.emitting = true;
		}
		foreach (Emitter emitter in closeEmitters) {
			emitter.emitting = false;
		}
		//player.transform.SetPositionAndRotation (playerPosition, playerRotation);
		player.transform.SetPositionAndRotation (gameObject.transform.position, gameObject.transform.rotation);
		player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		//Camera.main.transform.SetPositionAndRotation (cameraPosition, cameraRotation);
	}

	public void SetId(int id) {
		checkpointId = id;
	}

	public void SetPlayer(GameObject p) {
		player = p;
	}
}
