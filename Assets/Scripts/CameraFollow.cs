using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform Target1;
	public int CamZoom;
	public static int YOffset;
	public float LerpSpeed;

	void Start () {

		transform.position = new Vector3 (PlayerPrefs.GetFloat ("PosX"), PlayerPrefs.GetFloat ("PosY") + 1, 0);

	}

	void Update () {

		transform.position = new Vector3 (Target1.position.x, this.transform.position.y, CamZoom);

		float interpolation = LerpSpeed * Time.deltaTime;

		Vector3 position = this.transform.position;
		position.y = Mathf.Lerp(this.transform.position.y, Target1.transform.position.y + YOffset, interpolation);

		this.transform.position = position;

		if (Input.GetKeyUp (Controller.Up) || Input.GetKeyUp (Controller.Down) || Input.GetKeyUp (Controller.Left) || Input.GetKeyUp (Controller.Right)) {
			YOffset = 1;
		}

	}
}
