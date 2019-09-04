using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluctuactor : MonoBehaviour {

	float time;

	public float amplitude;
	public float frequency;

	Vector3 basePosition;

	void Start() {
		time = 0.0f;
		basePosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		float newY = Mathf.Sin (time * frequency) * amplitude;
		time += Time.deltaTime;
		transform.localPosition = basePosition + Vector3.up * newY;
	}
}
