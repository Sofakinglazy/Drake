using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeY = 0.05f;
	public float smoothTimeX = 0.05f;
	public Boundary boundary;
	public float xbound;
	public float ybound;

	private GameObject player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update (){
		if (Application.loadedLevel == 0) {
			boundary.xMax = 15.59f;
			boundary.xMin = -15.59f;
			boundary.yMax = 6.51f;
			boundary.yMin = -6.51f;
		} else if (Application.loadedLevel == 1) {
			boundary.xMax = 74f;
			boundary.xMin = -74f;
			boundary.yMax = 53f;
			boundary.yMin = -53f;
		}
		else if (Application.loadedLevel == 2) {
			boundary.xMax = -1.5f;
			boundary.xMin = -36f;
			boundary.yMax = 14f;
			boundary.yMin = 0f;
		}
		else if (Application.loadedLevel == 3) {
			boundary.xMax = 1.38f;
			boundary.xMin = -1.38f;
			boundary.yMax = 0f;
			boundary.yMin = 0f;
		}
	}

	void FixedUpdate(){
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);	
		if (posX < boundary.xMin) {
			posX = boundary.xMin;
		}
		if(posX > boundary.xMax){
			posX = boundary.xMax;
		}
		if (posY < boundary.yMin) {
			posY = boundary.yMin;
		}
		if (posY > boundary.yMax) {
			posY = boundary.yMax;
		}
		transform.position = new Vector3 (posX, posY, transform.position.z);

	}
	

}
