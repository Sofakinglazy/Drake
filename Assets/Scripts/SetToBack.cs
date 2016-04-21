using UnityEngine;
using System.Collections;

public class SetToBack : MonoBehaviour {

	void OnEnable(){
		transform.SetAsFirstSibling ();
	}
}
