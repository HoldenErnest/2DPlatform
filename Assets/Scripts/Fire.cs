using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public GameObject Target;
	public int Damage;
	bool Starting;

	void Start () {
		Starting = true;
		StartCoroutine (Thing());
	}

	void Update () {



	}

	void OnTriggerEnter2D (Collider2D Acoll) {


		if (Acoll.gameObject.tag != Target.tag && Acoll.gameObject.tag != "UI" && !Starting) {

			Destroy (this.gameObject, 0.05f);
			} else {

			if (Target.name == "Player" && Acoll.gameObject.tag == Target.tag) {

					HealthScript.CurrentHP -= Damage;
				Destroy (this.gameObject, 0.05f);
				}

			}

			

		}

	IEnumerator Thing () {

		yield return new WaitForSeconds (0.5f);
		Starting = false;

	}

}
