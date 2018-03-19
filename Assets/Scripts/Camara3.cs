using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara3 : MonoBehaviour {


	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (GameManager.instance.salaactual.transform.position.x, GameManager.instance.salaactual.transform.position.y, -10);
		Camera.main.orthographicSize = GameManager.instance.salaactual.transform.localScale.x/3f;
	}
}
