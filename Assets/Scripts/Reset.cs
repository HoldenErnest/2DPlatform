using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {



	void Start () {
		
	}

	void Update () {
		
	}

	void OnMouseUp () {

		PlayerPrefs.SetInt ("LevelsFinished", 0);

	}

}
