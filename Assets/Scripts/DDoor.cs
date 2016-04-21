using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DDoor : MonoBehaviour {

	public int LeveltoLoad;

	private GameMaster gm;

	void Start(){
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			gm.InputText.text=("(Wut? A DOOR?) [E] TO ENTER");
			SaveScore ();
		}
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			if (Input.GetKeyDown (KeyCode.E)) {
				Application.LoadLevel (LeveltoLoad);
				SaveScore ();
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			gm.InputText.text=("");
		}
   }

	void SaveScore(){
		PlayerPrefs.SetInt ("Score", gm.points);
	}

}
