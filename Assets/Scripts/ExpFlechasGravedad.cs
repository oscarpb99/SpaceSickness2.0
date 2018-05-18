using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpFlechasGravedad : MonoBehaviour {
	public GameObject panel;
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "player") {
			panel.SetActive(true);
		}
	
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			panel.SetActive (false);
		}
	}
}
