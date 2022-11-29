using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public Text NumText;
	public Text LevelDesc;
	public Text LevelName;
	SpriteRenderer SR;

	public string LevelDText;
	public string LevelNText;
	public string SceneName;
	public float xPOS;
	public float yPOS;
	public int LevelNum;

	void Start () {

		SR = GetComponent<SpriteRenderer> ();

	}

	void Update () {

		if (LevelNum <= PlayerPrefs.GetInt ("LevelsFinished") + 1) {
			
			SR.color = new Color (SR.color.r, SR.color.g, SR.color.b, 1);

		} else { 
			
			SR.color = new Color (SR.color.r, SR.color.g, SR.color.b, 0.5f);

		}

	}

	void OnMouseUp () {

		if (LevelNum <= PlayerPrefs.GetInt ("LevelsFinished") + 1) {
			SceneManager.LoadScene (SceneName);
			PlayerPrefs.SetFloat ("PosX", xPOS);
			PlayerPrefs.SetFloat ("PosY", yPOS);
		}
	}

	void OnMouseEnter () {

		if (LevelNum <= PlayerPrefs.GetInt ("LevelsFinished") + 1) {
			NumText.color = new Color (1f, 1f, 1f);
			LevelDesc.text = LevelDText;
			LevelName.text = LevelNText;
		}

	}
	void OnMouseExit () {

		NumText.color = new Color (0f, 0f, 0f);

	}

}
