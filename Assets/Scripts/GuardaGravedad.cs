using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaGravedad : MonoBehaviour {
	public bool gravarriba;//restriccion de habilidad de cambiar la gravedad en cualquiera de las 4 direcciones
	public bool gravabajo;
	public bool gravderecha;
	public bool gravizquierda;
	public bool grav0;//GRAVEDAD0
	public Rigidbody2D rb;

	public Vector2 gravedadsala;
	public bool oxigeno;//guarda la direccion de la gravedad propia de la sala
	private DireccionGravedad direccion;
	bool jugadorPresente = false;//determina si el jugador está en esta sala



    void Update(){
		if (gravedadsala.x < 0)
			direccion = DireccionGravedad.Izquierda;
		else if (gravedadsala.x > 0)
			direccion = DireccionGravedad.Derecha;
		else if (gravedadsala.y > 0)
			direccion = DireccionGravedad.Arriba;
		else if (gravedadsala.y < 0)
			direccion = DireccionGravedad.Abajo;
		else if (gravedadsala.x == 0 && gravedadsala.y == 0) {
			if (Input.GetKey (KeyCode.Space)) {
				rb.AddForce(transform.up * 7.6f);
			}
		}
			


		if (jugadorPresente) {
			GameManager.instance.grav = gravedadsala;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "player")
        {
            GameManager.instance.indicador.updateButtons(this);
            jugadorPresente = true;
        }
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "player")
			jugadorPresente = false;
	}
		 
    public DireccionGravedad GetDireccion ()
    {
        return direccion;
    }

	public bool GetPresencia (){
		return jugadorPresente;
	}
		

}
