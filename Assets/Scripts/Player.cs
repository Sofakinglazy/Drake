﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float maxSpeed=3;
	public float speed = 50f;
	public float jumppower=150f;
	public bool grounded;
	public bool died;
	public bool canDoubleJump;
	private Rigidbody2D rb2d;

	public int curHealth;
	public int maxHealth = 100;

	public Boundary boundary;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		curHealth = maxHealth;
		died = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool ("Died", died);
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3 (1, 1, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		if (Input.GetButtonDown ("Jump")) {
			if (grounded) {
				rb2d.AddForce (Vector2.up * jumppower);
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
					rb2d.AddForce (Vector2.up * jumppower);
				}
			}
		}
//		if (Input.GetButtonDown ("Jump")&&!grounded) {
//			rb2d.AddForce (Vector2.up * 100f);
//
//		}
		if (Input.GetAxis ("Horizontal") == 0) {
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		}

		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}

		if (curHealth <= 0) {
			Die ();
		}
	
	}

	void FixedUpdate(){
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 5f;


		float h = Input.GetAxis ("Horizontal");

		if (grounded) {
			rb2d.velocity = easeVelocity;
		}

		rb2d.AddForce ((Vector2.right * speed)*h);
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2(maxSpeed,rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2(-maxSpeed,rb2d.velocity.y);
		}

		rb2d.position = new Vector3
			(
				Mathf.Clamp(rb2d.position.x, boundary.xMin, boundary.xMax),
				rb2d.position.y,
				0.0f
			);
	}

	void Die(){
		died = true;
		Application.LoadLevel (Application.loadedLevel);
	}
		
	public void Damage(int dmg){
		curHealth -= dmg;
	}

	void OnLevelWasLoad(int thisLevel){
		transform.position = GameObject.FindGameObjectWithTag ("Respawn").transform.position;
	}

}

[System.Serializable]
public class Boundary{
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
}
