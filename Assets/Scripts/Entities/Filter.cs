using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filter : OperatorMonoBehaviour {

	GameObject glass;

	Color filterColor;
	public Color[] filterColorList;
	int filterColorId;

	// Use this for initialization
	void Start () {
		glass = transform.Find ("Glass").gameObject;
		filterColorId = 0;
		filterColor = filterColorList [filterColorId];
		glass.GetComponent<MeshRenderer> ().material.color = filterColor;
	}

	public override void OperateA() {
		;
	}

	public override void OperateB ()
	{
		filterColorId++;
		if (filterColorId == filterColorList.Length) {
			filterColorId = 0;
		}
		filterColor = filterColorList [filterColorId];
		glass.GetComponent<MeshRenderer> ().material.color = filterColor;
	}

	void OnTriggerEnter(Collider other) {

		// Hit by light
		if (other.gameObject.GetComponent<LightUnit> ()) {
			LightUnit lightUnit = other.gameObject.GetComponent<LightUnit> ();

			if (lightUnit.isNormal ()) {
				Vector3 inputVector = other.gameObject.GetComponent<Rigidbody> ().velocity;
				Color inputColor = other.gameObject.GetComponent<LightUnitColorManager> ().lightColor;
				GameObject newObject = Instantiate (other.gameObject, transform.position, Quaternion.identity);
				newObject.GetComponent<Rigidbody> ().velocity = inputVector;
				Color outputColor = inputColor;

				outputColor.r = (filterColor.r == 0f) ? 0f : inputColor.r;
				outputColor.g = (filterColor.g == 0f) ? 0f : inputColor.g;
				outputColor.b = (filterColor.b == 0f) ? 0f : inputColor.b;

				newObject.GetComponent<LightUnitColorManager> ().lightColor = outputColor;

				lightUnit.kill ();
			}
		}
	}
}
