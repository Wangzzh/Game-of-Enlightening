using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

	public GameObject player;

	Vector3 offset;

	// Use this for initialization
	void Awake () {
		offset = player.transform.position - transform.position;
		Debug.Log (offset);
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion cameraRotation = transform.rotation;
		transform.position = player.transform.position - cameraRotation * offset;
	}
}
