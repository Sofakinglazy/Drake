﻿using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Player player;
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerStay2D(Collider2D col){
		player.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col){
		player.grounded = false;
	}

}
