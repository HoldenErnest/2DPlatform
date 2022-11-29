using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	

	void Start () {



	}



	void Update () {

		if (Pause.IsPaused) {

			this.gameObject.SetActive (false);

		} else {
			this.gameObject.SetActive (true);
		}

	}
}
