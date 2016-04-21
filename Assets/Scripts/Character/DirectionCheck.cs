using UnityEngine;
using System.Collections;

public class DirectionCheck : MonoBehaviour {


//	private Player player;
	private SimpleEnemy Knight;

	// Use this for initialization
	void Start () {
//		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		//Knight =  GameObject.FindGameObjectWithTag ("Knight").GetComponent<SimpleEnemy> ();
		Knight=gameObject.GetComponentInParent<SimpleEnemy>();
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			Knight.transform.localScale = new Vector3 (-Knight.transform.localScale.x, 1, 1);
		}

	}
	

}
