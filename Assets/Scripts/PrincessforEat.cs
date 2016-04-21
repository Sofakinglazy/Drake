using UnityEngine;
using System.Collections;

public class PrincessforEat : MonoBehaviour {

	public GameObject meat;

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("FireBall")) {
			Destroy (col.gameObject);
			Instantiate (meat, gameObject.transform.position+new Vector3(0,1,0), gameObject.transform.rotation);
			Destroy (gameObject);
		}
	}

}
