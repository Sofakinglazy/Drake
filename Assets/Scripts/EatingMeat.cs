using UnityEngine;
using System.Collections;

public class EatingMeat : MonoBehaviour {

	private GameMaster gm;


	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			gm.EatText.text=("It seems delicious!([E] TO EAT)");

		}
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			if (Input.GetKeyDown (KeyCode.E)) {
				gm.EatText.text=("Oh it is sour!");
				Destroy (gameObject);
				gm.EatText.text=("");
			
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			gm.EatText.text=("");
		}
	}

}
