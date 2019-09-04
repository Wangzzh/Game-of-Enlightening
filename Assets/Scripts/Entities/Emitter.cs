using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : OperatorMonoBehaviour {

	public GameObject lightUnit;
	public Color[] emitColorList;
	public Color emitColor;

	public float interval;
	public Vector3 speed;

	int emitColorId = 0;

	public bool emitting;
	public EnergyIndicator energyIndicator;

	void Awake() {
		StartCoroutine (Emit ());
		emitColor = emitColorList [emitColorId];
	}
		

	public override void OperateA ()
	{
		emitting = !emitting;
		if (emitting) {
			energyIndicator.SetFill (1.0f);
		} else {
			energyIndicator.SetFill (0.0f);
		}
	}

	public override void OperateB ()
	{
		emitColorId++;
		if (emitColorId == emitColorList.Length) {
			emitColorId = 0;
		}
		emitColor = emitColorList [emitColorId];
	}

	IEnumerator Emit() {
		while (true) {
			yield return new WaitForSeconds (interval);
			if (emitting) {
				GameObject newObject = Instantiate (lightUnit, transform.position, Quaternion.identity);
				newObject.GetComponent<Rigidbody> ().velocity = speed;
				newObject.GetComponent<LightUnitColorManager> ().lightColor = emitColor;
			}
		}
	}
}
