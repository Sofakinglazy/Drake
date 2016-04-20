using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public Transform spawnPoint;

	void Start(){
		SpawnPlayer ();
	}

	void SpawnPlayer(){
		Instantiate (player, spawnPoint.position, Quaternion.identity);
	}
}
