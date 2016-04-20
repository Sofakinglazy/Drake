using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class DialoguePanel : MonoBehaviour {

	public Text conversation;
	public GameObject characterIcon;
	public Button yesButton;
	public Button noButton;
	public GameObject dialoguePanelObject;

	private static DialoguePanel dialoguePanel;

	public static DialoguePanel instance (){
		if (!dialoguePanel) {
			dialoguePanel = FindObjectOfType (typeof (DialoguePanel)) as DialoguePanel;
			if (!dialoguePanel) {
				Debug.LogError ("Cannot find the dialogue panel.");
			}
		}
		return dialoguePanel;
	}

	public void Choice (string conversation, UnityAction yesEvent, UnityAction noEvent){
		dialoguePanelObject.SetActive (true);

		yesButton.onClick.RemoveAllListeners ();
		yesButton.onClick.AddListener (yesEvent);
		yesButton.onClick.AddListener (ClosePanel);

		noButton.onClick.RemoveAllListeners ();
		noButton.onClick.AddListener (noEvent);
		noButton.onClick.AddListener (ClosePanel);

		this.conversation.text = conversation;

		this.characterIcon.SetActive (false);
		yesButton.gameObject.SetActive (true);
		noButton.gameObject.SetActive (true);

	}

	void ClosePanel(){
		dialoguePanelObject.SetActive (false);
	}
}
