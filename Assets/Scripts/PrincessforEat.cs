using UnityEngine;
using System.Collections;

public class PrincessforEat : MonoBehaviour {

	public GameObject meat;
	private GameMaster gm;
	public GameObject apple;

	void Start(){
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("FireBall")) {
			Destroy (col.gameObject);
			Instantiate (meat, gameObject.transform.position+new Vector3(0,1,0), gameObject.transform.rotation);
			Destroy (gameObject);
		}
		if(col.CompareTag("Player")){
			gm.PrincessText.text=("I Can Sell U Some Food!([E] FOR YES)");
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			if (Input.GetKeyDown (KeyCode.E)) {
				Instantiate (apple, gameObject.transform.position+new Vector3(-5,0,0), gameObject.transform.rotation);
				gm.points -= 5;

			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			gm.PrincessText.text=("");

		}
	}

}
