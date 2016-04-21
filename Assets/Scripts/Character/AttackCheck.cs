using UnityEngine;
using System.Collections;

public class AttackCheck : MonoBehaviour {

	private Player player;
	private SimpleEnemy Knight;
	private float v;
	void Start(){
//		 player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		Knight =  GameObject.FindGameObjectWithTag ("Knight").GetComponent<SimpleEnemy> ();
		v = Knight.velocity;
	}
	void Update(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

//	void OnTriggerEnter2D(Collider2D col){
//		if (col.CompareTag ("Player")) {
//			player.Damage (20);
//		}
//	}

	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
				player.Damage (1);
//			Knight.velocity = 0;
			Knight.anim.SetBool ("Attack", true);
//			StartCoroutine (player.Knockback (0.05f,500,player.transform.position));
			player.knockbackCount=player.knockbackLength;
			if (player.transform.position.x < transform.position.x) {
				player.knockfromRight = true;
			} else {
				player.knockfromRight = false;
			}

				

			}
	}

	void OnTriggerExit2D(Collider2D col){
//		Knight.velocity = v;
		Knight.anim.SetBool ("Attack", false);
	}

}
