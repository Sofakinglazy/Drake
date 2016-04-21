using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class HiddenLever : MonoBehaviour
{

	public GameObject[] icons;
	public GameObject fakePrincess;
	public GameObject realPrincess;

	private bool spaceAccepted;
	private bool inConveration;
	private DialoguePanel dialogue;
	private string[] conversations;

	void Start ()
	{
		spaceAccepted = false;
		inConveration = false;
		dialogue = DialoguePanel.instance ();
		conversations = TextManager.text2;
	}

	void Update ()
	{
		if (inConveration) {
			if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Jump")) {
				spaceAccepted = true;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			inConveration = true;
			StartCoroutine (Talk ());
		}
	}

	void FindGold ()
	{
		Application.LoadLevel (1);
	}

	void FightKnights ()
	{
		Application.LoadLevel (2);
	}

	void EatPrincess ()
	{
		Instantiate (realPrincess, fakePrincess.transform.position, fakePrincess.transform.rotation);
		Destroy (fakePrincess);
		Destroy (gameObject);
	}

	void BuyApple ()
	{
		Instantiate (realPrincess, fakePrincess.transform.position, fakePrincess.transform.rotation);
		Destroy (fakePrincess);
		Destroy (gameObject);
	}

	//	void AssignText(){
	//		conversations[0] = "Please don't eat me. \n I can sell you something.";
	//		conversations[1] = "What are you going to give me?";
	//		conversations[2] = "I can give you some apples.";
	//		conversations[3] = "Should I accept apples?";
	//	}

	IEnumerator Talk ()
	{
		for (int i = 0; i < conversations.Length - 1; i++) {
			int nIcon = i % icons.Length;
			dialogue.Speak (icons [nIcon], conversations [i]);
			yield return new WaitUntil (() => spaceAccepted);
			spaceAccepted = false;
		}
		int lastIcon = (conversations.Length - 1) % icons.Length;
		dialogue.Choice (icons [lastIcon], conversations [conversations.Length - 1], BuyApple, EatPrincess);
		inConveration = false;
		yield return new WaitUntil (() => spaceAccepted);
	}
}


