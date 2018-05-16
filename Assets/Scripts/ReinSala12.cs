using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinSala12 : MonoBehaviour {
	public GameObject sala12;
	Transform x;
	void Start(){
		x = sala12.transform;
	}
		
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "player") {
			sala12.transform.position = x.position;
			sala12.transform.rotation = x.rotation;
		}
	}
}
