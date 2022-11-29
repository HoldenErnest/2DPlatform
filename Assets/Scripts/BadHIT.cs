using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadHIT : MonoBehaviour {

	public CircleCollider2D AttackCollision;
	bool hit;
	bool canGetHit;
	Rigidbody2D rBody;
	public int MaxHP;
	public int currentHP;
	public GameObject Player;
	bool IsDead; 

	void Start () {
		hit = false;
		currentHP = MaxHP;
		rBody = GetComponent<Rigidbody2D> ();
		canGetHit = true;
		IsDead = false;
	}

	void Update () {

		if (hit && canGetHit && IsDead == false) {
			StartCoroutine (Sec ());
			if (Player.transform.rotation.y == 0f) {
				rBody.AddForce (new Vector2 (-2, 3f), ForceMode2D.Impulse);
			} else {
				rBody.AddForce (new Vector2 (2, 3f), ForceMode2D.Impulse);
			}
			canGetHit = false;
		}

		if (currentHP <= 0 && IsDead == false) {
			Destroy (this.gameObject, 0.5f);
			GemCOUNTER.OverallScore += 55;
			IsDead = true;
		}


	}

	void OnTriggerEnter2D (Collider2D Hit) {

		if (Hit == AttackCollision) {
			currentHP -= 1;
			hit = true;
			GemCOUNTER.OverallScore += 15;
		}

	}
		
	IEnumerator Sec () {

		yield return new WaitForSeconds (0.5f);
		hit = false;
		canGetHit = true;

	}

}
