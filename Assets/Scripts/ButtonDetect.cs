using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDetect : MonoBehaviour {

	Dropdown DropSelect;

	void Start () {

		DropSelect = GetComponent<Dropdown> ();

		if (DropSelect.gameObject.name == "LeftDropdown") {
			DropSelect.value = PlayerPrefs.GetInt("LeftKey");
		}
		if (DropSelect.gameObject.name == "RightDropdown") {
			DropSelect.value = PlayerPrefs.GetInt("RightKey");
		}
		if (DropSelect.gameObject.name == "UpDropdown") {
			DropSelect.value = PlayerPrefs.GetInt("UpKey");
		}
		if (DropSelect.gameObject.name == "DownDropdown") {
			DropSelect.value = PlayerPrefs.GetInt("DownKey");
		}
		if (DropSelect.gameObject.name == "AttackDropdown") {
			DropSelect.value = PlayerPrefs.GetInt("AttackKey");
		}
	}

	void Update () {
		if (DropSelect.gameObject.name == "LeftDropdown") {
			PlayerPrefs.SetInt ("LeftKey", DropSelect.value);
		}
		if (DropSelect.gameObject.name == "RightDropdown") {
			PlayerPrefs.SetInt ("RightKey", DropSelect.value);
		}
		if (DropSelect.gameObject.name == "UpDropdown") {
			PlayerPrefs.SetInt ("UpKey", DropSelect.value);
		}
		if (DropSelect.gameObject.name == "DownDropdown") {
			PlayerPrefs.SetInt ("DownKey", DropSelect.value);
		}
		if (DropSelect.gameObject.name == "AttackDropdown") {
			PlayerPrefs.SetInt ("AttackKey", DropSelect.value);
		}

	}
}
