using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public int points;

	public Text pointsText;
	public Text InputText;
	public Text EatText;
	public Text PrincessText;

	void Start(){
		if (PlayerPrefs.HasKey ("Score")) {
			if (Application.loadedLevel == 0) {
				PlayerPrefs.DeleteKey ("Score");
				points = 0;
			} else {
				points = PlayerPrefs.GetInt ("Score");
			}
		}
	}

	
	// Update is called once per frame
	void Update() {
		pointsText.text = ("Money:" + points);
	}
}
