using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartSceneOnDrop : MonoBehaviour {

	public CheckpointManager checkpointManager;
	public AudioClip deathSound;

	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -10) {
			checkpointManager.RestoreGame ();
			AudioSource.PlayClipAtPoint (deathSound, Camera.main.transform.position);
		}
	}
}
