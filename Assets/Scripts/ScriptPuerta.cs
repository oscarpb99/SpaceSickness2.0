using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPuerta : MonoBehaviour {
	public bool bloqueada;
	bool abierta=false;
	int contador;
	public bool jugadorEnRango=false;
	public GameObject collider;
	

	void FixedUpdate () {
	if (!abierta && Input.GetKey (KeyCode.Space)) 
		{
			if (jugadorEnRango)
			{
				abierta = true;
				contador = 100;
			}
		} else 
		{
			if (contador <= 0)
				abierta = false;
			else
				contador--;
		}

		AbreCierra ();

	}

	void AbreCierra(){
		collider.GetComponent<BoxCollider2D> ().enabled = !abierta;
		GetComponent<SpriteRenderer>().enabled = !abierta; 
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			jugadorEnRango = true;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			jugadorEnRango = false;
		}

	}

	void Desbloquear(){
		bloqueada = false;
	}
}
		
