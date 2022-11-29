using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBad : MonoBehaviour {

	public LayerMask TopLayer;
	Rigidbody2D rBody;
	public float speed;

	void Start () {

		rBody = GetComponent<Rigidbody2D> ();

	}

	void Update () {

		RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.right, 0.3f, TopLayer);
		if (hit.collider != null) {
			transform.Rotate (0, 180, 0);
			speed = -speed;
		} else {
			rBody.velocity = new Vector2 (speed, rBody.velocity.y); //always running...
		}


	}
}
