using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravedad0 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Physics2D.gravity = new Vector2 (0,0.5f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Aqui se cambia mi gravedad a gravedad 0");
		//other.attachedRigidbody.gravityScale;
		Physics2D.gravity = new Vector2 (0,0);
	}
}
