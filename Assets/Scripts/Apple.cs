using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	private GameMaster gm;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			gm.EatText.text=("Oh I Dont Like Fruit!([E] TO KICK AWAY)");

		}
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			if (Input.GetKeyDown (KeyCode.E)) {
				gm.EatText.text=("Oh it is sour!");
				rb2d.velocity = new Vector2 (10*col.gameObject.transform.localScale.x*-1,0);

			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			gm.EatText.text=("");
		}
	}

}
