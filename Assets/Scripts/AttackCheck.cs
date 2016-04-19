using UnityEngine;
using System.Collections;

public class AttackCheck : MonoBehaviour {

	private Player player;
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			player.Damage (20);
		}
	}

//	void OnTriggerStay2D(Collider2D col){
//		player.curHealth -= 50;
//	}

//	void OnTriggerExit2D(Collider2D col){
//		player.grounded = false;
//	}

}
