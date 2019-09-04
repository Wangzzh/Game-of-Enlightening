using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStarMovement : MonoBehaviour {

	Vector3 basePosition;
	float maxRadius = 100f;
	float maxFrequency = 0.8f;

	float frequency;
	float radius;

	float time;

	// Use this for initialization
	void Start () {
		basePosition = transform.position;
		radius = Random.value * maxRadius;
		frequency = Random.value * maxFrequency;
		time = Random.value * 3f;

		transform.position = new Vector3 (
			basePosition.x + radius * Mathf.Sin(time * frequency),
			basePosition.y,
			basePosition.z + radius * Mathf.Cos(time * frequency)
		);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (
			basePosition.x + radius * Mathf.Sin(time * frequency),
			basePosition.y,
			basePosition.z + radius * Mathf.Cos(time * frequency)
		);
		time += Time.deltaTime;
	}
}
