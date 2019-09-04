using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDamper : MonoBehaviour {

	public GameObject desiredCamera;

	public float speedDamper;
	public float positionDamper;
	public float rotationDamper;
	public float rotationSpeedDamper;

	Vector3 speed;
	Vector3 rotationSpeed;

	void Start() {
		//transform.position = desiredCamera.transform.position;
		//transform.rotation = desiredCamera.transform.rotation;
		speed = Vector3.zero;
		rotationSpeed = Vector3.zero;
	}

	void Update () {
		Vector3 positionDifference = desiredCamera.transform.position - transform.position;
		speed += speedDamper * positionDifference;
		transform.position += positionDamper * positionDifference;
		transform.position += speed;

		Vector3 rotationDifference = desiredCamera.transform.rotation.eulerAngles - transform.rotation.eulerAngles;

		// Fix overflow issues
		while (rotationDifference.y > 180f)
			rotationDifference.y -= 360f;
		while (rotationDifference.y < -180f)
			rotationDifference.y += 360f;

		if (rotationSpeed.y >= 10f)
			rotationSpeed.y = 10f;
		if (rotationSpeed.y <= -10f)
			rotationSpeed.y = -10f;

		rotationSpeed += rotationSpeedDamper * rotationDifference;
		transform.Rotate (rotationDamper * rotationDifference);
		transform.Rotate (rotationSpeed);
	}
}
