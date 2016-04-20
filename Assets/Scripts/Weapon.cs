using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate=0;
	public float damage=0;
	float timeToFire = 0;
	public Transform firePoint;
	private Player player;
	public GameObject bullet;
	public float nextfire;

	void Awake (){
		firePoint = transform.FindChild ("FirePoint");

	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	
	}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetKeyDown (KeyCode.Q)&&Time.time>nextfire) {
			nextfire = Time.time + fireRate;	
			  Shoot ();
			}
		
	
	}

	void Shoot(){
//		Debug.Log ("Test");
//		GameObject bulletClone;
//		Vector2 direction = new Vector2 (player.transform.localScale.x,player.transform.localScale.y);
//		bulletClone = Instantiate (bullet, firePoint.position, firePoint.rotation);
//		bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * 20;
		Instantiate(bullet,firePoint.position,firePoint.rotation);


	}

}
