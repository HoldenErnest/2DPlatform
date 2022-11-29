using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmed : MonoBehaviour {

	public static bool harmed;
	public CircleCollider2D AttackColl;

	void Start () {
		
	}

	void Update () {



	}

	void OnCollisionStay2D (Collision2D DColl) {

		if (DColl.gameObject.tag == "Death") {

			HealthScript.CurrentHP = 0;

		}
		if (DColl.gameObject.tag == "Bad1" && harmed == false && !DColl.collider.IsTouching(AttackColl)) {
			
			harmed = true;
			HealthScript.CurrentHP -= 1;
			StartCoroutine (StartC ());


		}
		if (DColl.gameObject.tag == "Bad2" && harmed == false && !DColl.collider.IsTouching(AttackColl)) {

			harmed = true;
			HealthScript.CurrentHP -= 2;
			StartCoroutine (StartC ());


		}

	}

	IEnumerator StartC () {

		yield return new WaitForSeconds (0.5f);
		harmed = false;
		Controller.canGetHarmed = true;

	}

}
