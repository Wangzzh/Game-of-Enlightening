using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStarColor : MonoBehaviour {

	float maxR = 0.05f;
	float maxG = 0.05f;
	float maxB = 0.2f;

	// Use this for initialization
	void Start () {
		Color color = new Color (Random.value * maxR, Random.value * maxG, Random.value * maxB);
		GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", color);
	}
}
