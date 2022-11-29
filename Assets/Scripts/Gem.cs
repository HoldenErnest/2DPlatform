using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

	public static int GemsCollected;
	bool collected;

	void Start () {
		GemsCollected = 0;
		collected = false;
	}

	void Update () {



	}

	void OnTriggerEnter2D (Collider2D Coll) {

		if (Coll.gameObject.tag.Equals("Player") && !collected) {

			GemCOUNTER.OverallScore += 125;
			GemsCollected += 1;
			collected = true;
			Destroy (this.gameObject, 0f);

		}

	}
}
