using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyIndicator : MonoBehaviour {

	GameObject[] columns;

	float maxScale;

	// Use this for initialization
	void Start () {
		columns = new GameObject[4];
		for (int i = 0; i < 4; i++) {
			columns [i] = transform.GetChild (i).gameObject;
			maxScale = columns [i].transform.GetChild (0).transform.localScale.y;
		}
	}

	public void SetFill(float percent) {
		foreach (GameObject column in columns) {
			Vector3 newScale = column.transform.GetChild (0).transform.localScale;
			newScale.y = maxScale * percent;
			column.transform.GetChild (0).transform.localScale = newScale;
		}
	}
}
