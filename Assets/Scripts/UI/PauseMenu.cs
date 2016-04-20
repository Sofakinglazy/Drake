using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseMenuObject;
	public Button resumeButton;
	public Button restartButton;
	public Button quitButton;

	private static PauseMenu pauseMenu;

	public static PauseMenu instance (){
		if (!pauseMenu) {
			pauseMenu = FindObjectOfType (typeof(PauseMenu)) as PauseMenu;
			if (!pauseMenu) {
				Debug.LogError ("Cannot find the pause menu!");
			}
		}
		return pauseMenu;
	}

	public void Pause(){
		PauseMenuObject.SetActive (true);
		Time.timeScale = 0;

		resumeButton.onClick.RemoveAllListeners ();
		resumeButton.onClick.AddListener (Resume);
		resumeButton.onClick.AddListener (CloseMenu);

		restartButton.onClick.RemoveAllListeners ();
		restartButton.onClick.AddListener (Restart);
		restartButton.onClick.AddListener (CloseMenu);

		quitButton.onClick.RemoveAllListeners ();
		quitButton.onClick.AddListener (Quit);
		quitButton.onClick.AddListener (CloseMenu);
	}

	void Resume(){
	}

	void Quit(){
		Application.Quit ();
	}

	void Restart(){
		Application.LoadLevel (Application.loadedLevel);
	}

	void CloseMenu(){
		PauseMenuObject.SetActive (false);
		Time.timeScale = 1;
	}


}
