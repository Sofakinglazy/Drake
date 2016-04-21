using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestDialogue : MonoBehaviour {

	private DialoguePanel dialogue;
	private UnityAction myYesAction;
	private UnityAction myNoAction;

	void Awake (){
		dialogue = DialoguePanel.instance ();

		myYesAction = new UnityAction (TestYesAction);
		myNoAction = new UnityAction (TestNoAction);

	}

	public void TestCYS(){
//		dialogue.Choice ("Would you go to heaven?\n OR go to hell?", myYesAction, myNoAction);
	}

	void TestYesAction (){
		Debug.Log ("That is the yes event");
	}

	void TestNoAction (){
		Debug.Log ("That is the no event");
	}
}
