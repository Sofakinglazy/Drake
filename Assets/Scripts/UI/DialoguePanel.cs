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
				Debug.LogError ("Cannot find the dialogue panel!");
			}
		}
		return dialoguePanel;
	}

	public void Speak (string conversation){
		dialoguePanelObject.SetActive (true);
		Time.timeScale = 0;

		this.conversation.text = conversation;

		yesButton.gameObject.SetActive (false);
		noButton.gameObject.SetActive (false);
	}

	public void Speak (GameObject icon, string conversation){
		Speak (conversation);
		this.characterIcon.GetComponent<Image>().sprite = icon.GetComponent<SpriteRenderer>().sprite;
		this.characterIcon.SetActive (true);
	}

	public void Choice (GameObject icon, string question, UnityAction yesEvent, UnityAction noEvent){
		dialoguePanelObject.SetActive (true);
		Time.timeScale = 0;

		this.conversation.text = question;
		this.characterIcon.GetComponent<Image>().sprite = icon.GetComponent<SpriteRenderer>().sprite;

		yesButton.onClick.RemoveAllListeners ();
		yesButton.onClick.AddListener (yesEvent);
		yesButton.onClick.AddListener (ClosePanel);

		noButton.onClick.RemoveAllListeners ();
		noButton.onClick.AddListener (noEvent);
		noButton.onClick.AddListener (ClosePanel);


		this.characterIcon.SetActive (true);
		yesButton.gameObject.SetActive (true);
		noButton.gameObject.SetActive (true);

	}

	void ClosePanel(){
		dialoguePanelObject.SetActive (false);
		Time.timeScale = 1;
	}
}
