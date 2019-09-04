using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

	public int currentCheckpoint = -1;
	public GameObject player;

	public Checkpoint [] checkpoints;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < checkpoints.Length; i++) {
			checkpoints [i].SetId(i);
			checkpoints [i].SetPlayer (player);
		}
		if (currentCheckpoint != -1) {
			RestoreGame ();
		}
	}

	public void UpdateState(int id) {
		if (id >= currentCheckpoint)
			currentCheckpoint = id;
	}

	public void RestoreGame() {
		Debug.Log ("Restore Game");
		checkpoints[currentCheckpoint].RestoreState ();
	}
}
