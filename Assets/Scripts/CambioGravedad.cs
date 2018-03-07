using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioGravedad : MonoBehaviour {
	public float gravedad;//fuerza con la que atrae los objetos. Valor positivo.
	Rigidbody2D rb;
	public float margenmovimiento;//velocidad máxima a la que se puede cambiar la direccion de la gravedad. Valor positivo.
	//Disponibilidad de cambio de gravedad en cada una de las 4 direcciones, en el juego completo dependen de las variables guardadas en cada sala.
	public bool gravedadArriba;
	public bool gravedadAbajo;
	public bool gravedadIzquierda;
	public bool gravedadDerecha;


	void Awake(){
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}


	void Update () {

		if (Mathf.Abs(rb.velocity.x) <= margenmovimiento && Mathf.Abs(rb.velocity.y)<= margenmovimiento)
		{
			CambiarGravedad ();
		}
	}

	void CambiarGravedad(){
		
		if (Input.GetKey (KeyCode.UpArrow) && gravedadArriba) Physics2D.gravity = new Vector2 (0f, gravedad);
		
		if (Input.GetKey (KeyCode.DownArrow) && gravedadAbajo) Physics2D.gravity = new Vector2 (0f, -gravedad);
		
		if (Input.GetKey (KeyCode.RightArrow) && gravedadDerecha) Physics2D.gravity = new Vector2 (gravedad, 0f);
		
		if (Input.GetKey (KeyCode.LeftArrow) && gravedadIzquierda) Physics2D.gravity = new Vector2 (-gravedad, 0f);
		
	}
}
