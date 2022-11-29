using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	
	public LayerMask TopLayer;

	public float speed;
	bool onGround;
	private Animator anim;
	public Rigidbody2D rBody;
	public GameObject Player;
	bool UnderThing = false;
	float AddSpeed;
	public float MaxSpeed;
	public CircleCollider2D cCollider;
	public static bool canGetHarmed;
	bool Attacked;
	public float JumpHight;

	bool canJump;

	public static KeyCode AttackButton;
	public static KeyCode Left;
	public static KeyCode Right;
	public static KeyCode Down;
	public static KeyCode Up;

	void Start () {
		Harmed.harmed = false;

		transform.position = new Vector3 (PlayerPrefs.GetFloat ("PosX"), PlayerPrefs.GetFloat ("PosY"), 0);

		if (PlayerPrefs.GetInt ("LeftKey") == 0) {
			Left = KeyCode.LeftArrow;
		} else {
			if (PlayerPrefs.GetInt ("LeftKey") == 1) {
				Left = KeyCode.A;
			} else {
				Left = KeyCode.None;
			}
		}
		if (PlayerPrefs.GetInt ("RightKey") == 0) {
			Right = KeyCode.RightArrow;
		} else {
			if (PlayerPrefs.GetInt ("RightKey") == 1) {
				Right = KeyCode.D;
			} else {
				Right = KeyCode.None;
			}
		}
		if (PlayerPrefs.GetInt ("UpKey") == 0) {
			Up = KeyCode.UpArrow;
		} else {
			if (PlayerPrefs.GetInt ("UpKey") == 1) {
				Up = KeyCode.W;
			} else {
				if (PlayerPrefs.GetInt ("UpKey") == 2) {
					Up = KeyCode.Space;
				} else {
					Up = KeyCode.None;
				}
			}
		}
		if (PlayerPrefs.GetInt ("DownKey") == 0) {
			Down = KeyCode.DownArrow;
		} else {
			if (PlayerPrefs.GetInt ("DownKey") == 1) {
				Down = KeyCode.S;
			} else {
				if (PlayerPrefs.GetInt ("DownKey") == 2) {
					Down = KeyCode.LeftControl;
				} else {
					Down = KeyCode.None;
				}
			}
		}
		if (PlayerPrefs.GetInt ("AttackKey") == 0) {
			AttackButton = KeyCode.Space;
		} else {
			if (PlayerPrefs.GetInt ("AttackKey") == 1) {
				AttackButton = KeyCode.Mouse0;
			} else {
				AttackButton = KeyCode.None;
			}
		}

		anim = GetComponent<Animator> ();
		rBody = GetComponent<Rigidbody2D> ();
		AddSpeed = 0;
		canGetHarmed = true;
		canJump = true;
	}

	void Update () {
	
		if (Harmed.harmed && canGetHarmed) {

			if (this.transform.rotation.y == 0f) {
				rBody.AddForce (new Vector2 (3, 5f), ForceMode2D.Impulse);
			} else {
				rBody.AddForce (new Vector2 (-3, 5f), ForceMode2D.Impulse);
			}
			canGetHarmed = false;
		}


		if (Input.GetKey (Left) || Input.GetKey (Right)) {
			anim.SetBool ("Walking", true);
		} else {
			anim.SetBool ("Walking", false);
		}

		if (onGround && !UnderThing) {

			if (Input.GetKey (AttackButton)) {								//Attack------------------
				Attacked = true;
				anim.SetBool ("Attack", true);
				AddSpeed = 0f;
			} else {
				anim.SetBool ("Attack", false);
				Attacked = false;
			}


			if (Input.GetKey (Up)) {										//Jumping-----------
				if (UnderThing == false && canJump == true) {
					rBody.AddForce (new Vector2 (0, JumpHight), ForceMode2D.Impulse);
					anim.SetBool ("Jumped", true);
					CameraFollow.YOffset = 0;
					canJump = false;
					StartCoroutine (JumpPause ());
				}
			} else {
				anim.SetBool ("Jumped", false);	//Jump: if you jump then jump again as you touch the ground you can do a tall jump.
			}

			if (Input.GetKey (Down)) {										//Crouching--------
				anim.SetBool ("Crouched", true);
				if (AddSpeed > 0) {
					AddSpeed -= 0.05f;
				}
				CameraFollow.YOffset = -2;
			} else {
				anim.SetBool ("Crouched", false);
				if (UnderThing == false && !Attacked) {
					speed = 1f;
				}
			}
		}

		if (Input.GetKey (Left)) {											//Running----------
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			rBody.velocity = new Vector2 (-speed - AddSpeed, rBody.velocity.y);
			CameraFollow.YOffset = 1;
			if (AddSpeed < MaxSpeed && !Input.GetKey (Down) && !UnderThing && !Attacked) {     //AttackFIX
				AddSpeed += 0.075f;
			}
		}
		if (Input.GetKey (Right)) {											//Running---------
			transform.localRotation = Quaternion.Euler (0, 180, 0);
			rBody.velocity = new Vector2 (speed + AddSpeed, rBody.velocity.y);
			CameraFollow.YOffset = 1;
			if (AddSpeed < MaxSpeed && !Input.GetKey (Down) && !UnderThing && !Attacked) {			//AttackFIX
				AddSpeed += 0.075f;
			}
		}

		if (Input.GetKeyUp (Left) || Input.GetKeyUp (Right)) {
				AddSpeed = 0;
		}
			
		if (rBody.velocity.y < -3f) {
			CameraFollow.YOffset = -2;
		}

		anim.SetFloat ("Speed", rBody.velocity.x);
		anim.SetFloat ("YVelocity", rBody.velocity.y);

		RaycastHit2D hit = Physics2D.Raycast(Player.transform.position, transform.up, 0.5f, TopLayer);
		if (hit.collider != null) {
			UnderThing = true;
			anim.SetBool ("UnderObject", true);
		} else {
			UnderThing = false;
			anim.SetBool ("UnderObject", false);
		}

	}
		

	void OnCollisionStay2D (Collision2D Coll) {
		if (Coll.collider.IsTouching (cCollider) && Coll.gameObject.tag == "Ground" && !Input.GetKey (Down)) { //if the hit collider is hitting the circle collider
			CameraFollow.YOffset = 1;
			onGround = true;
			anim.SetBool ("OnGround", true);
		}
	}

		void OnCollisionExit2D (Collision2D XColl) {

		if (XColl.gameObject.tag == "Ground") {
				onGround = false;
				anim.SetBool ("OnGround", false);
		}
			
	}
		
	IEnumerator JumpPause () {

		yield return new WaitForSeconds (0.1f);
		canJump = true;

	}



}