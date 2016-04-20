﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeY = 0.05f;
	public float smoothTimeX = 0.05f;
	public float xbound;
	public float ybound;

	private GameObject player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate(){
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);	
		if (posX < -xbound) {
			posX = -xbound;
		}
		if(posX > xbound){
			posX = xbound;
		}
		if (posY < -ybound) {
			posY = -ybound;
		}
		if (posY > ybound) {
			posY = ybound;
		}
		transform.position = new Vector3 (posX, posY, transform.position.z);

	}
	

}
