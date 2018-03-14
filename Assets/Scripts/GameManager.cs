using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DireccionGravedad
{
    Izquierda, Derecha, Arriba, Abajo
}

public class GameManager : MonoBehaviour {
	public Vector2 grav;
	public static GameManager instance = null;
    public GuardaGravedad currentGravity;
	public GameObject salaactual;//sala donde se encuentra el jugador
	float oxigeno;//cantidad de oxigeno restante en el tanque del jugador
	public float drenaoxigeno;//periodo de gasto del oxigeno

	void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else
			Destroy (this.gameObject);

		oxigeno = 100;
	}
		
	
	// Update is called once per frame
	void Update () {
		if (!salaactual.GetComponent<GuardaGravedad> ().oxigeno) {
			InvokeRepeating ("RestaOxigeno", drenaoxigeno, drenaoxigeno);
		} else
			Invoke ("AumentaOxigeno", 1f);
		Physics2D.gravity = grav;//se encarga de actualizar el estado de gravedad en base a una variable que es modificada en cada sala (grav)
	}

    public DireccionGravedad GetDirection()
    {
        return currentGravity.GetDireccion();
    }

    public void SetCurrentGravity(GuardaGravedad g)
    {
        currentGravity = g;
    }

	void RestaOxigeno() {
		oxigeno--;
	}

	void AumentaOxigeno(){
		oxigeno = 100;
	}

	public float GetOxigeno(){
		return oxigeno;
	}
}
