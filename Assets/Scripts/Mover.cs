using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;
	private Player player;
	private Rigidbody2D rb2d;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (speed*player.transform.localScale.x*-1,rb2d.velocity.y);
		gameObject.transform.localScale = new Vector3 (player.transform.localScale.x * -1, player.transform.localScale.y, player.transform.localScale.z);
	}
	

}
