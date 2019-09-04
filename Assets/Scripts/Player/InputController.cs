using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour {

	Rigidbody rb;

	public float speed;
	public float speedDamping;

	public float jumpSpeed;
	public float jumpDampingFactor;

	public AudioClip jumpSound;

	int jumpable;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		jumpable = 0;
		rb.velocity = 0.01f * Vector3.forward;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		
		Vector3 lastVelocity = rb.velocity;

		// Move
		Vector3 inputVector = new Vector3 (Input.GetAxisRaw ("Horizontal") / 2.0f, 0.0f, Input.GetAxisRaw ("Vertical")).normalized * 1.1f;
		Quaternion cameraRotation = Camera.main.transform.rotation;
		inputVector = cameraRotation * inputVector;

		float outputX = lastVelocity.x + speedDamping * jumpDampingFactor * (inputVector.x * speed - lastVelocity.x);
		float outputY = lastVelocity.y;
		float outputZ = lastVelocity.z + speedDamping * jumpDampingFactor * (inputVector.z * speed - lastVelocity.z);

		if (jumpable > 0 && Input.GetAxisRaw ("Jump") > 0.0f) {
			outputY = jumpSpeed;
			AudioSource.PlayClipAtPoint (jumpSound, Camera.main.transform.position);
		}

		rb.velocity = new Vector3(outputX, outputY, outputZ);
	}

	void OnCollisionEnter(Collision other) {
		if (other.collider.gameObject.GetComponent<Floor> ()) {
			jumpable += 1;
			jumpDampingFactor = 1f;
		}
	}

	void OnCollisionExit(Collision other) {
		if (other.collider.gameObject.GetComponent<Floor> ()) {
			jumpable -= 1;
			jumpDampingFactor = 0.1f;
		}
	}
}
