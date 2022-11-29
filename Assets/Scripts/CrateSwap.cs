using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSwap : MonoBehaviour {

	public Color Heavycol;
	public Color Lightcol;
	private SpriteRenderer SR;
	public bool Heavy;
	bool chose;

	void Start () {
		chose = false;
		SR = GetComponent<SpriteRenderer> ();

		if (this.gameObject.layer == 11) {
			Heavy = true;
		} else {
			Heavy = false;
		}


	}

	void Update () {

	}

	void OnMouseUp () {

		if (this.gameObject.layer == 11) { //if already heavy
									//change to lightbox
			SR.color = Lightcol;
			Heavy = false;
			this.gameObject.layer = 0;
			chose = true;

		} 
		if (this.gameObject.layer == 0 && !chose) {
			
			this.gameObject.layer = 11;
			SR.color = Heavycol;
			Heavy = true;
		}
		chose = false;
	}

}
