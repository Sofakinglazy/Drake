using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;

	private Rigidbody2D rb2d;

	void Start(){
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (speed,rb2d.velocity.y);
	}
	

}
