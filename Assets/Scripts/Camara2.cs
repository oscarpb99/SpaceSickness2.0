using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara2 : MonoBehaviour {
	public GameObject player;
	public float speed = 2.0f;
	
	void Update () {
		Vector3 position = this.transform.position;

		position.y = Mathf.Lerp (this.transform.position.y, player.transform.position.y, speed * Time.deltaTime);
		position.x = Mathf.Lerp (this.transform.position.x, player.transform.position.x, speed * Time.deltaTime);

		this.transform.position = position;
	}
}
