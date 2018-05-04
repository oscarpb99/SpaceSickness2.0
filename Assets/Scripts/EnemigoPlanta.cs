using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPlanta : MonoBehaviour {
	GameObject sala;
    public GameObject head;
	Vector3 poshead;

	void Start(){
		poshead = head.transform.position;
	}
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
			gameObject.GetComponent<Rotacion> ().rotacion = new Vector3 (0, 0, 0);
			poshead = head.transform.position;
            head.transform.position = col.gameObject.transform.position;
			col.gameObject.GetComponent<PlayerController> ().Die ();
			Invoke ("DevolverCabeza", 0.5f);
        }
	}

	void DevolverCabeza(){
		head.transform.position = poshead;
		gameObject.GetComponent<Rotacion> ().ReseteaRotacion ();
	}

	public GameObject GetSala(){
		return sala;
	}
}
