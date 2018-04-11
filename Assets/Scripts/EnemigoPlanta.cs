using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPlanta : MonoBehaviour {
	GameObject sala;
    public GameObject head;

	// Update is called once per frame
	void Update () {
		if (sala != null) {
			if (!sala.GetComponent<GuardaGravedad> ().oxigeno)
				Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "sala")
			sala = col.gameObject;
        if (col.gameObject.tag == "player")
        {
            head.transform.position = col.gameObject.transform.position;
            col.gameObject.GetComponent<PlayerController>().Die();
        }
	}
}
