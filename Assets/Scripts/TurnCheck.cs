using UnityEngine;
using System.Collections;

public class TurnCheck : MonoBehaviour {

	private SimpleEnemy Knight;

	// Use this for initialization
	void Start () {
		Knight =  GameObject.FindGameObjectWithTag ("Knight").GetComponent<SimpleEnemy> ();
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Knight")) {
			Knight.transform.localScale = new Vector3 (-Knight.transform.localScale.x, 1, 1);
			Knight.velocity = -Knight.velocity;
		}
	}
	

}
