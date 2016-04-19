using UnityEngine;
using System.Collections;

public class SimpleEnemy : MonoBehaviour {

	public float velocity = 1f;
	public Transform sightEnd;
	public Transform sightStart;
	public Transform AttackStart;
	public Transform AttackEnd;
	public bool attack;
	public bool colliding;
	private Rigidbody2D rb2d;
	private Animator anim;
	public LayerMask Dectectwhat;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2 (-velocity, rb2d.velocity.y);
		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position);
		attack = Physics2D.Linecast (AttackStart.position, AttackEnd.position);
//		if (colliding) {
//			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
//			velocity *= -1;
//		}
		if (attack||colliding) {
			anim.SetBool ("Attack", true);
		} else {
			anim.SetBool ("Attack", false);
		}
			
	
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine (sightStart.position, sightEnd.position);
		Gizmos.DrawLine (AttackStart.position, AttackEnd.position);
	}

}
