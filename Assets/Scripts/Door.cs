using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private bool enter; 
	public TestDialogue test;

	void Start (){
		enter = false;
	}

	void Update (){
		if (enter == true && Input.GetKeyDown (KeyCode.UpArrow)) {
			test.TestCYS ();
//			Application.LoadLevel("Scene1");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			DontDestroyOnLoad (other.gameObject);
			enter = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			DontDestroyOnLoad (other.gameObject);
			enter = false;
		}
	}
}
