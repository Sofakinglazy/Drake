﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public int points;

	public Text pointsText;

	
	// Update is called once per frame
	void Update () {
		pointsText.text = ("Money:" + points);
	}
}
