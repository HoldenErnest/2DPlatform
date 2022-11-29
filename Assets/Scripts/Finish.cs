using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

	public int LevelNum;
	bool touchedGoal;
	public int GemsNeeded;
	public static bool Victory;
	public GameObject NEgems;

	void Start () {
		touchedGoal = false;
		Victory = false;
	}

	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D coll) {

		if (coll.gameObject.tag == "Player") {

			if (GemsNeeded > Gem.GemsCollected) { // keep in mind if they cant actualy go back to collect it, may be on purpose

				NEgems.SetActive(true);
				StartCoroutine(waiter());
			}

			if (GemsNeeded <= Gem.GemsCollected) { //Conditions Needed to  win--

				Victory = true;

				if (!touchedGoal && LevelNum > PlayerPrefs.GetInt ("LevelsFinished")) { // if a new level was beat/to unlock next level
						
					PlayerPrefs.SetInt ("LevelsFinished", PlayerPrefs.GetInt ("LevelsFinished") + 1);
					touchedGoal = true;
					NEgems.SetActive(false);
				}
			}
		}

	}

	IEnumerator waiter() {

		yield return new WaitForSeconds (3f);
		NEgems.SetActive(false);

	}


}
