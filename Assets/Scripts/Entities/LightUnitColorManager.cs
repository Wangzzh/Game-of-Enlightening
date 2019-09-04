using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUnitColorManager : MonoBehaviour {

	public Color lightColor;
	Color lastColor;

	TrailRenderer trail;

	// Use this for initialization
	void Start () {
		trail = GetComponent<TrailRenderer> ();
		lastColor = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		if (lastColor != lightColor) {
			trail.material.SetColor ("_EmissionColor", lightColor);
			lastColor = lightColor;
		}

		if (lightColor.r == 0f && lightColor.g == 0f && lightColor.b == 0f) {
			Destroy (gameObject);
		}
	}
}
