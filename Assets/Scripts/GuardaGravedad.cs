using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaGravedad : MonoBehaviour {
	public bool gravarriba;//restriccion de habilidad de cambiar la gravedad en cualquiera de las 4 direcciones
	public bool gravabajo;
	public bool gravderecha;
	public bool gravizquierda;
	public Vector2 gravedadsala;//guarda la direccion de la gravedad propia de la sala
	private DireccionGravedad direccion;
	bool jugadorPresente = false;//determina si el jugador está en la sala actual
	int i;//índice del array
	const int maxobjsala=10;//maximo de objetos de la sala
	GameObject [] objetosala = new GameObject[maxobjsala];//array de gameobjects presentes en la sala etiquetados como obj

	void Awake() {
		i = 0;

	}

    void Update(){
		if (gravedadsala.x < 0)
			direccion = DireccionGravedad.Izquierda;
		else if (gravedadsala.x > 0)
			direccion = DireccionGravedad.Derecha;
		else if (gravedadsala.y > 0)
			direccion = DireccionGravedad.Arriba;
		else if  (gravedadsala.y < 0)
			direccion = DireccionGravedad.Abajo;

		if (jugadorPresente)//si el jugador está en la sala se activan los rigidbody de los objetos de la sala
			Activa ();
		else//si el jugador se sale de la sala se desactivan los rigidbody de los objetos de la sala
			Paraliza ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			jugadorPresente = true;
		} 
		if (col.gameObject.tag == "obj") {
			objetosala [i] = col.gameObject;//se guarda en el array las instancias de los objetos de la sala
			i++;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "player")
			jugadorPresente = false;
	}

	void Paraliza(){
		for (int i = 0; i < objetosala.Length; i++) {
			objetosala [i].GetComponent<Rigidbody2D> ().Sleep ();//duerme el rigidbody de los objetos de la sala guardados en el array
		}
	}

	void Activa(){
		for (int i = 0; i < objetosala.Length; i++) {
			objetosala [i].GetComponent<Rigidbody2D> ().WakeUp ();//despierta el rigidbody de los objetos de la sala guardados en el array
		}
	}

	 
    public DireccionGravedad GetDireccion ()
    {
        return direccion;
    }




}
