﻿using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
//			&& Input.GetButtonDown(KeyCode.UpArrow)) {
			DontDestroyOnLoad (other.gameObject);
			Application.LoadLevel("Scene1");

		}

	}
}
