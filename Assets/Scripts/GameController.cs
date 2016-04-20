using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject camera;
	public Transform spawnPoint;
	private PauseMenu pauseMenu;

	void Start(){
		SpawnPlayer ();
		InstantiateCamera ();
		pauseMenu = PauseMenu.instance ();
	}

	void Update (){
		if (Input.GetButtonDown ("Pause")) {
			pauseMenu.Pause ();
		}
	}

	void SpawnPlayer(){
		Instantiate (player, spawnPoint.position, Quaternion.identity);
	}

	void InstantiateCamera(){
		Vector3 origin = new Vector3 (0f, 0f, -10f);
		Instantiate (camera, origin, Quaternion.identity);
	}
}
