using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class HiddenKnot : MonoBehaviour {

	public GameObject playerIcon;
	public GameObject npcIcon;

	private bool spaceAccepted;
	private bool inConveration;
	private DialoguePanel dialogue;
	private string[] conversations;

	void Start (){
		spaceAccepted = false;
		inConveration = false;
		dialogue = DialoguePanel.instance ();
		conversations = new string[4];
		AssignText ();
	}

	void Update (){
		if (inConveration) {
			if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) {
				spaceAccepted = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			inConveration = true;
			StartCoroutine (Talk());
		}
	}	

	void eatPrincess(){
		Debug.Log("Eat princess!");
	}

	void buyApple(){
		Debug.Log("Buy apple!");
	}

	void AssignText(){
		conversations[0] = "Please don't eat me. \n I can sell you something.";
		conversations[1] = "What are you going to give me?";
		conversations[2] = "I can give you some apples.";
		conversations[3] = "Should I accept apples?";
	}

	IEnumerator Talk (){
		for (int i = 0; i < conversations.Length - 1; i++) {
			dialogue.Speak (conversations[i]);
			yield return new WaitUntil(() => spaceAccepted);
			spaceAccepted = false;
		}
		dialogue.Choice (conversations[3], eatPrincess, buyApple);
		inConveration = false;
		yield return new WaitUntil(() => spaceAccepted);
	}
}
