using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private bool enter; 

	void Start (){
		enter = false;
	}

	void Update (){
		if (enter == true && Input.GetKeyDown (KeyCode.UpArrow)) {
			Application.LoadLevel("Scene1");
			Debug.Log("Should be in scene1");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			DontDestroyOnLoad (other.gameObject);
			enter = true;
			Debug.Log ("Player stands at the door.");
		}
	}
}
