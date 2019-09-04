using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActivator : MonoBehaviour {

	public Gate gate;

	float openTime;
	bool opened;

	public bool penetrateLight;
	public AudioClip hitSound;

	void Start() {
		opened = false;
		openTime = -0.1f;
		StartCoroutine (Blink ());
	}


	// Update is called once per frame
	void Update () {
		if (opened) {
			openTime -= Time.deltaTime;
			if (openTime < 0.0f) {
				opened = false;
				gate.Close ();
			}
		} else {
			if (openTime > 0.0f) {
				gate.Open ();
				opened = true;
			}
		}
	}

	float brightness;

	IEnumerator Blink() {
		for (int i = 0; i <= 10; i++) {
			brightness = 0.5f - (float)i * 0.05f;
			GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", new Color (brightness, brightness, brightness));
			yield return new WaitForSeconds (0.05f);
		}
		for (int i = 0; i <= 10; i++) {
			brightness = (float)i * 0.05f;
			GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", new Color (brightness, brightness, brightness));
			yield return new WaitForSeconds (0.05f);
		}
		if (opened) {
			yield return Lit ();
		} else {
			yield return Blink ();
		}
	}

	IEnumerator Lit() {
		brightness = 0.5f;
		GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", new Color (brightness, brightness, brightness));
		for (int i = 0; i <= 10; i++) {
			brightness = 0.5f + (float)i * 0.05f;
			GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", new Color (brightness, brightness, brightness));
			yield return new WaitForSeconds (0.05f);
		}
		while(true){
			yield return new WaitForSeconds(1.0f);
			if (!opened) {
				for (int i = 0; i <= 10; i++) {
					brightness = 1f - (float)i * 0.05f;
					GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", new Color (brightness, brightness, brightness));
					yield return new WaitForSeconds (0.05f);
				}
				yield return Blink ();
				break;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		LightUnit lightUnit = other.gameObject.GetComponent<LightUnit> ();
		if (lightUnit && lightUnit.isNormal()) {
			if (!penetrateLight)
				lightUnit.kill ();
			if (openTime < 0.0f) {
				AudioSource.PlayClipAtPoint (hitSound, Camera.main.transform.position);
			}
			openTime = 1.0f;
		}
	}
}
