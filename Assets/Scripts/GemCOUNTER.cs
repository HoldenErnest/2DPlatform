using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCOUNTER : MonoBehaviour {

	public Text GemTXT;
	public Text ScoreTXT;
	public static int OverallScore;

	void Start () {

		OverallScore = 0;

	}

	void Update () {

		GemTXT.text = "Gems: " + Gem.GemsCollected;

		ScoreTXT.text = "Score: " + OverallScore;

	}
}
