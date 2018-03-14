using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script que congela los objetos que estén en una sala distinta de la sala en la que esté el jugador. Todos los objetos físicos como cajas, etc deben llevarlo
public class SleepObjetos : MonoBehaviour {
	GameObject sala=null;
	
	// Update is called once per frame
	void Update () {
		if (sala != null) {
			if (sala==GameManager.instance.salaactual)//si la sala donde está el objeto es la misma que la sala en la que está el jugador 
				GetComponent<Rigidbody2D> ().simulated = true;//descongela el objeto
			else
				GetComponent<Rigidbody2D> ().simulated=false;//congela el objeto

		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "sala")
			sala = col.gameObject;//guarda la referencia de la sala donde se encuentra el objeto

	}
}
