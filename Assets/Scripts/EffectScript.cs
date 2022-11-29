using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour {

	bool collected;
	public int healthAdded;

	void Start () {
		collected = false;
	}

	void Update () {



	}

	void OnCollisionEnter2D (Collision2D Coll) {

		if (Coll.gameObject.tag == "Player" && !collected) {

			HealthScript.CurrentHP += healthAdded;
			collected = true;
			Destroy (this.gameObject, 0f);

		}
		collected = false;
	}

}
