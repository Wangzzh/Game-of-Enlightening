using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour{

	bool operatingA;
	bool operatingB;

	public AudioClip operatorSound;

	Selecter selecter;
	OperatorMonoBehaviour operatorBehaviour;

	void Start () {
		operatorBehaviour = GetComponent<OperatorMonoBehaviour> ();
		selecter = GetComponent<Selecter> ();
		operatingA = false;
		operatingB = false;
	}

	void Update() {

		// Input Control
		if (selecter.selected && Input.GetAxisRaw ("OperateA") > 0.5f) {
			if (!operatingA) {
				operatingA = true;
				AudioSource.PlayClipAtPoint (operatorSound, Camera.main.transform.position);
				operatorBehaviour.OperateA ();
			}
		} else {
			operatingA = false;
		}

		if (selecter.selected && Input.GetAxisRaw ("OperateB") > 0.5f) {
			if (!operatingB) {
				operatingB = true;
				AudioSource.PlayClipAtPoint (operatorSound, Camera.main.transform.position);
				operatorBehaviour.OperateB ();
			}
		} else {
			operatingB = false;
		}

	}
}
