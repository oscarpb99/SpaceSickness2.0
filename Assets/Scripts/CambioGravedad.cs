using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioGravedad : MonoBehaviour {
	Rigidbody2D rb;
	public float margenmovimiento;//velocidad máxima a la que se puede cambiar la direccion de la gravedad. Valor positivo.
	//Disponibilidad de cambio de gravedad en cada una de las 4 direcciones, en el juego completo dependen de las variables guardadas en cada sala.
	bool gravedadArriba;
	bool gravedadAbajo;
	bool gravedadIzquierda;
	bool gravedadDerecha;
	public GameObject sala;


	void Awake(){
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}


	void Update () {

		if (Mathf.Abs(rb.velocity.x) <= margenmovimiento && Mathf.Abs(rb.velocity.y)<= margenmovimiento)
		{
			CambiarGravedad ();
		}
		GameManager.instance.grav = sala.GetComponent<GuardaGravedad> ().gravedadsala;//cambia el estado de gravedad que guarda el gamemanager por el de la sala actual
	}

	void CambiarGravedad(){
		 //cambia la variable de estado de gravedad en la sala actual
		if (Input.GetKey (KeyCode.UpArrow) && gravedadArriba) sala.gameObject.GetComponent<GuardaGravedad> ().gravedadsala = new Vector2 (0f, 20f);
		
		if (Input.GetKey (KeyCode.DownArrow) && gravedadAbajo) sala.gameObject.GetComponent<GuardaGravedad>().gravedadsala = new Vector2 (0f, -20f);
		
		if (Input.GetKey (KeyCode.RightArrow) && gravedadDerecha) sala.gameObject.GetComponent<GuardaGravedad>().gravedadsala = new Vector2 (20f, 0f);
		
		if (Input.GetKey (KeyCode.LeftArrow) && gravedadIzquierda) sala.gameObject.GetComponent<GuardaGravedad>().gravedadsala = new Vector2 (-20f, 0f);
		
	}

	void OnTriggerEnter2D (Collider2D room){
		if (room.gameObject.tag == "sala") {//al entrar en una sala se guardan los bool que definen en que direccion puedes cambiar la gravedad según los datos de la sala.
			sala=room.gameObject;
			gravedadArriba = room.gameObject.GetComponent<GuardaGravedad> ().gravarriba;//guarda el bool de la posibilidad de cambiar en segun que direccion presente en la sala
			gravedadAbajo = room.gameObject.GetComponent<GuardaGravedad> ().gravabajo;
			gravedadDerecha = room.gameObject.GetComponent<GuardaGravedad> ().gravderecha;
			gravedadIzquierda = room.gameObject.GetComponent<GuardaGravedad> ().gravizquierda;
			GameManager.instance.grav = room.gameObject.GetComponent<GuardaGravedad> ().gravedadsala;//en cuanto se entra en la sala se cambia el estado de la gravedad al estado de gravedad guardado en la sala
		}


	}
}
