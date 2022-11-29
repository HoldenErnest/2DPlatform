using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public static bool IsPaused;
	public GameObject PauseMenuItems;

	void Start () {
		
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.P)) {

			if (Time.timeScale == 1) {
				PauseMenuItems.gameObject.SetActive (true);
				Time.timeScale = 0;
				IsPaused = false;
			} else {
				PauseMenuItems.gameObject.SetActive (false);
				Time.timeScale = 1;
				IsPaused = false;
			}

		}

	}

	void OnMouseUp () {
		if (Time.timeScale == 1) {
			PauseMenuItems.gameObject.SetActive (true);
			Time.timeScale = 0;
			IsPaused = false;
		} else {
			PauseMenuItems.gameObject.SetActive (false);
			Time.timeScale = 1;
			IsPaused = false;
		}

	}

}
