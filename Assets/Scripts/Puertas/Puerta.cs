using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour {
	bool open;
	Vector2 initialPosition;
	bool activateOpenDoor;

	void Awake(){
		open = false;
		activateOpenDoor = false;
		initialPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
	}

	void Update () {
		//Pulsar P equivaldria en un futuro a pulsar un boton o lo que fuese, deberia de ser sustituido por el evento que deberia de abrir la puerta
		if(Input.GetKey(KeyCode.P)){
			activateOpenDoor = true;				
		}
			
		if (activateOpenDoor) {
			openDoor ();
		}

	}

	//Dice si la puerta esta abierta o no
	bool isOpen(){
		if (open) {
			return true;
		} else {
			return false;
		}
	}

	void openDoor(){
		if (gameObject.transform.position.y >= initialPosition.y + 2) {
			open = true;
		} else {
			//Aqui en un futuro podria ir la animacion de abrir la puerta
			transform.Translate (new Vector2(0,1) * Time.deltaTime);
		}

	}
}
