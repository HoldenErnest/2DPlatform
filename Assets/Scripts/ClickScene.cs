using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClickScene : MonoBehaviour {

	public Sprite SpriteOver;
	public Sprite SpriteExit;
	public bool LoadScene;
	public bool OpenCurrentScene;

	public string SceneToLoad;
	SpriteRenderer SR;
	void Start () {
		SR = GetComponent<SpriteRenderer> ();
	}
	

	void Update () {

		if (Input.GetKeyDown (KeyCode.O)) {

				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
				Time.timeScale = 1;

			}


	}

	void OnMouseUp () {

		if (OpenCurrentScene) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			Time.timeScale = 1;
		}

		if (LoadScene && !OpenCurrentScene) { 
			SceneManager.LoadScene (SceneToLoad);
			Time.timeScale = 1;
		}
	}


	void OnMouseEnter () {
		SR.sprite = SpriteOver;
	}
	void OnMouseExit () {
		SR.sprite = SpriteExit;
	}

}
