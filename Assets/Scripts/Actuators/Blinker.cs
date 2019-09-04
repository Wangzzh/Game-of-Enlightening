using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour {

	float time;
	Vector3 baseScale;

	public float fluctuatePercent;
	public float frequency;

	// Use this for initialization
	void Start () {
		time = 0.0f;
		baseScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = baseScale * (1 + fluctuatePercent * Mathf.Sin (frequency * time));
		time += Time.deltaTime;
	}
}
