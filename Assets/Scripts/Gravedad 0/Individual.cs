using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour {
	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		rb.gravityScale = 0f;
		if (Input.GetKey (KeyCode.Space)) {
			rb.AddForce(transform.up * 5);
		}

	}

}
