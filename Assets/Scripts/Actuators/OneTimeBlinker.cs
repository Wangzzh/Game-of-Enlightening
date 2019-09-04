using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneTimeBlinker : MonoBehaviour {

	public void Blink(string showText) {
		time = Mathf.PI * 3f / frequency;
		gameObject.GetComponent<Text>().text = showText;
	}

	float time;
	Vector3 baseScale;

	public float frequency;
	public float amplitude;

	// Use this for initialization
	void Start () {
		time = 0.0f;
		baseScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (time * frequency >= 0f) {
			if (time * frequency >= 0.5f * Mathf.PI && time * frequency <= 2.5f * Mathf.PI) {
				transform.localScale = baseScale * (1.0f - amplitude) + baseScale * (amplitude * Mathf.Sin(frequency * time));
			} else {
				transform.localScale = baseScale * Mathf.Sin (frequency * time);
			}
			time -= Time.deltaTime;
			if (time < 0f) {
				transform.localScale = Vector3.zero;
				gameObject.GetComponent<Text>().text = "";
			}
		}
	}
}
