using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 2f;

	void Update () {
		transform.Translate (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, 0);
	}
}
