using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPuerta : MonoBehaviour {
	public bool bloqueada;
	bool abierta=false;
	int contador;
	public bool jugadorEnRango=false;
	

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
		GetComponent<BoxCollider2D> ().enabled = !abierta;
	}
}
		
