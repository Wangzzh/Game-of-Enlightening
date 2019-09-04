using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector : OperatorMonoBehaviour {

	GameObject glass;

	void Start() {
		glass = transform.Find ("Glass").gameObject;
	}

	public override void OperateA() {
		glass.transform.Rotate (0.0f, 22.5f, 0.0f);
	}

	public override void OperateB() {
		glass.transform.Rotate (0.0f, -22.5f, 0.0f);
	}


	void OnTriggerEnter(Collider other) {

		// Hit by light
		if (other.gameObject.GetComponent<LightUnit> ()) {
			LightUnit lightUnit = other.gameObject.GetComponent<LightUnit> ();

			if (lightUnit.isNormal ()) {
				Vector3 normalVector = glass.transform.localRotation * Vector3.right;
				Vector3 inputVector = other.gameObject.GetComponent<Rigidbody> ().velocity;
				// Debug.Log ("Normal = " + normalVector.ToString ());
				// Debug.Log ("Input = " + inputVector.ToString ());

				Quaternion normalQuaternion = Quaternion.FromToRotation (inputVector, normalVector);
				// Debug.Log ("Q = " + normalQuaternion.eulerAngles.ToString());
				Vector3 outputVector = -(normalQuaternion * (normalQuaternion * inputVector));
				// Debug.Log ("Output = " + outputVector.ToString ());

				if ((outputVector - inputVector).magnitude >= 1) {
					GameObject newObject = Instantiate (other.gameObject, transform.position, Quaternion.identity);
					newObject.GetComponent<Rigidbody> ().velocity = outputVector;
				}
				lightUnit.kill ();
			}
		}
	}
}

