using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBrais : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			col.GetComponent<PlayerController> ().spawn = this.GetComponent<Transform> ();
		}

	}
}
