using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSTAT : MonoBehaviour {

	public Camera maincam;
	public Text TxtString;
	GameObject Target;

	void Start () {

	}
		
	void Update () {

		if (Input.GetKeyDown (KeyCode.Mouse1)) {

			TxtString.text = "";

			transform.position = maincam.ScreenToWorldPoint (Input.mousePosition); //move text to object < v
			transform.Translate (0, 0, 5);


		}

		if (Input.GetKeyUp (KeyCode.Mouse1)) {

			StartCoroutine (Delay ());

		}


	}

	IEnumerator Delay () {
		yield return new WaitForSeconds (0.3f);
		if (!Input.GetKey (KeyCode.Mouse1)) {

			transform.position = new Vector3 (0, 100, 0);//Unshow text

		}

	}


	void OnTriggerEnter2D (Collider2D coll) {

		Target = coll.gameObject;

		if (coll.gameObject.name.Contains("Bad1")) { //Slime Baddie
			TxtString.text = "[Slime]\nMass: " + Target.GetComponent<Rigidbody2D> ().mass + "\nHealth: " + Target.gameObject.GetComponent<BadHIT>().currentHP + "\n\n\n";

		}
		if (coll.gameObject.name.Contains("MovingBaddie")) { //mover

			TxtString.text = "[Mover]\nStrength: " + Target.GetComponent<Rigidbody2D>().mass + "\nSpeed: " + Mathf.Abs(Target.GetComponent<MoveBad>().speed) * 10 + "\nHealth: " + Target.GetComponent<BadHIT>().currentHP + "\n\n\n";

		}
		if (coll.gameObject.name.Contains("Crate")) { //Crate

			TxtString.text = "[Crate]\nMass: " + Target.GetComponent<Rigidbody2D> ().mass + "\nHeavy: " + Target.GetComponent<CrateSwap> ().Heavy + "\n\n\n";

		}
		if (coll.gameObject.name.Contains("Emmiter")) { //Emmiter

			TxtString.text = "[Emmiter]\nFireRate: 1/" + Target.GetComponent<Emmite> ().FireRate + "\nFireSpeed: " + Target.GetComponent<Emmite> ().ObjectSpeed + "\nObject: " + Target.GetComponent<Emmite> ().Object.name + "\n\n\n";

		}
		if (coll.gameObject.name.Contains("HealthAdd")) { //healthadder

			TxtString.text = "[Health]\nContains: " + Target.GetComponent<EffectScript> ().healthAdded + "/5\n\n\n";

		}

	}

}
