using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public int StartHP;
	public static int CurrentHP;
	public Slider HPBar;

	void Start () {
		
		HPBar.maxValue = StartHP;
		CurrentHP = StartHP;

	}

	void Update () {



		HPBar.value = CurrentHP;
		if (CurrentHP > HPBar.maxValue) {
			CurrentHP -= 1;
		}
		if (CurrentHP < 1) {

			EndGame.GameOver = true;

		}

	}
}
