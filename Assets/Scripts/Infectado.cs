using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infectado : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			col.gameObject.GetComponent<PlayerController> ().Die ();
		}
	}
}
