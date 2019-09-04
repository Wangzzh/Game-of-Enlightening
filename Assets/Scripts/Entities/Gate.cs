using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

	bool open = false;
	GameObject leftDoor;
	GameObject rightDoor;

	GameObject leftEnergy;
	GameObject rightEnergy;

	Vector3 leftClosePosition;
	Vector3 rightClosePosition;
	public Vector3 leftDesiredPosition;
	public Vector3 rightDesiredPosition;

	public float damping;

	void Start() {
		leftDoor = transform.Find ("Left Column").Find ("Left Gate").gameObject;
		rightDoor = transform.Find ("Right Column").Find ("Right Gate").gameObject;

		leftClosePosition = leftDoor.transform.localPosition;
		rightClosePosition = rightDoor.transform.localPosition;

		leftDesiredPosition = leftClosePosition;
		rightDesiredPosition = rightClosePosition;
	}

	public void Open() {
		if (!open) {
			leftDesiredPosition = Vector3.zero;
			rightDesiredPosition = Vector3.zero;
			open = true;
		}
	}

	public void Close() {
		if (open) {
			leftDesiredPosition = leftClosePosition;
			rightDesiredPosition = rightClosePosition;
			open = false;
		}
	}

	void FixedUpdate() {
		leftDoor.transform.position += damping * (leftDesiredPosition - leftDoor.transform.localPosition);
		rightDoor.transform.position += damping * (rightDesiredPosition - rightDoor.transform.localPosition);
	}
}
