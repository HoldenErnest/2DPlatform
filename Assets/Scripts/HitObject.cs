using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : MonoBehaviour {

	bool hit;
	bool canGetHit;
	Rigidbody2D rBody;
	public GameObject Player;
	public CircleCollider2D AttackCollision;

	void Start () {
		canGetHit = true;
		rBody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (hit && canGetHit) {
			StartCoroutine (Sec ());
			if (Player.transform.rotation.y == 0f) {
				rBody.rotation = 30;
				rBody.AddForce (new Vector3 (-15, 20f), ForceMode2D.Impulse);
			} else {
				rBody.rotation = -30;
				rBody.AddForce (new Vector2 (15, 20f), ForceMode2D.Impulse);
			}
			canGetHit = false;
		}
	}

	void OnTriggerEnter2D (Collider2D Hit) {

		if (Hit == AttackCollision) {
			hit = true;
		}

	}

	IEnumerator Sec () {

		yield return new WaitForSeconds (0.25f);
		hit = false;
		canGetHit = true;

	}

}
