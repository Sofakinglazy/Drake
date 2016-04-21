using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class HiddenKnot : MonoBehaviour {

	private DialoguePanel dialogue;

	void Start (){
		dialogue = DialoguePanel.instance ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			string conversation = "Please don't eat me. \n I can sell you something if you get the money.";
			dialogue.Choice (conversation, eatPrincess, buyApple);
		}
	}

	void eatPrincess(){
		Debug.Log("Eat princess!");
	}

	void buyApple(){
		Debug.Log("Buy apple!");
	}
}
