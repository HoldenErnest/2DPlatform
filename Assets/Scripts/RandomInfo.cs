using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomInfo : MonoBehaviour {

	private Text MyText;
	int currentNum;
	public List<string> Texts;

	void Start () {

		MyText = GetComponent<Text> ();
		currentNum = (Random.Range (0, Texts.Count - 1));

	}

	void Update () {

		MyText.text = Texts[currentNum];

	}
}
