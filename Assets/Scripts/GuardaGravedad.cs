using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaGravedad : MonoBehaviour {
	public bool gravarriba;//restriccion de habilidad de cambiar la gravedad en cualquiera de las 4 direcciones
	public bool gravabajo;
	public bool gravderecha;
	public bool gravizquierda;
	public GameObject[] objetos= new GameObject[10];

	public Vector2 gravedadsala;
	public Vector2 gravedadinicial;
	public bool oxigeno;//guarda la direccion de la gravedad propia de la sala
	private DireccionGravedad direccion;
	bool jugadorPresente = false;//determina si el jugador está en esta sala

	int s;

	void Start(){
		for (int i = 0; i < objetos.Length; i++) {
			objetos [i] = null;
		}

		s = 0;
	}

    void Update(){
		if (gravedadsala.x == 0 && gravedadsala.y == 0)
			direccion = DireccionGravedad.Gravedad0;
		else if (gravedadsala.x < 0)
			direccion = DireccionGravedad.Izquierda;
		else if (gravedadsala.x > 0)
			direccion = DireccionGravedad.Derecha;
		else if (gravedadsala.y > 0)
			direccion = DireccionGravedad.Arriba;
		else if (gravedadsala.y < 0)
			direccion = DireccionGravedad.Abajo;
		
		
		if (jugadorPresente) {
			GameManager.instance.grav = gravedadsala;
            GameManager.instance.SetCurrentGravity(this);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "player")
        {
			GameObject ultimasala=GameManager.instance.GetUltimaSala ();

			if(ultimasala==null||(ultimasala!=this.gameObject)){
				gravedadsala=gravedadinicial;
				GameManager.instance.SetUltimaSala (this.gameObject);
			}

           if(GameManager.instance.indicador != null)
               GameManager.instance.indicador.updateButtons(this);
			

            jugadorPresente = true;

        }
		if (col.gameObject.tag == "obj") {
			objetos [s] = col.gameObject;
			s++;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			jugadorPresente = false;
		}
			
	}
		 
    public DireccionGravedad GetDireccion ()
    {
        return direccion;
    }

	public bool GetPresencia (){
		return jugadorPresente;
	}
		
	public GameObject[] GetObjetos (){
		return objetos;

	}

    public void ZeroGravity()
    {
        gravedadsala = Vector2.zero;
    }

    public void ResetGravity()
    {
        gravedadsala = gravedadinicial;
    }
}
