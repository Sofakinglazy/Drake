using UnityEngine;
using System.Collections;

public class Edge : MonoBehaviour {

	private Player player;


	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			player.Damage (player.maxHealth);
			Debug.Log (player.maxHealth);
		}
	}

}
