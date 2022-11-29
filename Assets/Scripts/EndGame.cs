using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	public SpriteRenderer Sprite;
	public static bool GameOver;
	float ColorChange;
	public float ChangeSpeed;
	public Vector3 Colors;

	void Start () {
		GameOver = false;
		ColorChange = 0f;
	}
	void Update () {

		if (GameOver && !Finish.Victory) {
			Sprite.enabled = true;
			Sprite.color = new Color (Colors.x, Colors.y, Colors.z, ColorChange);
			StartCoroutine(CSpeed());

		}

	}

	IEnumerator CSpeed() {

		yield return new WaitForSeconds (0.07f);
		ColorChange += ChangeSpeed;

	}

}
