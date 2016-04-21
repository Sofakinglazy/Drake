using UnityEngine;
using System.Collections;

public class TurnCheck : MonoBehaviour {

//	private SimpleEnemy Knight;

	// Use this for initialization
	void Start () {
//		Knight =  GameObject.FindGameObjectWithTag ("Knight").GetComponent<SimpleEnemy> ();
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Knight")) {
			col.gameObject.transform.localScale = new Vector3 (-col.gameObject.transform.localScale.x, 1, 1);
//			col.gameObject.velocity = -col.gameObject.velocity;
		}
	}
	

}
