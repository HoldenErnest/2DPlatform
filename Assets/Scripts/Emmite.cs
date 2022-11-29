using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmite : MonoBehaviour {

	public float FireRate;
	public float ObjectSpeed;
	public GameObject Object;
	bool allowed;
	public float DestroyTime;
	Vector3 Positions;


	void Start () {
		allowed = true;
		Positions.x = this.transform.position.x;
		Positions.y = this.transform.position.y;
		Positions.z = 5;
	}

	void Update () {
		if (allowed) {
			StartCoroutine (start ());
			allowed = false;
		}
	}

	IEnumerator start () {
		
		yield return new WaitForSeconds (FireRate);
		Emmit ();
		allowed = true;

	}


	void Emmit () {
		var TheObject = (GameObject)Instantiate (Object, Positions, this.transform.rotation);

		TheObject.GetComponent<Rigidbody2D>().velocity = TheObject.transform.right * ObjectSpeed;
		Destroy(TheObject, DestroyTime);


	}

}
