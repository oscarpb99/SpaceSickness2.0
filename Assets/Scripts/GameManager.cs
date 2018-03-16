using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
	public float oxigeno;//cantidad de oxigeno restante en el tanque del jugador
	public float maxoxigeno=600;
	public GameObject oxigenbar;
	public GameObject camera;
	public GameObject player;


	void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else
			Destroy (this.gameObject);
	}
		
	// Update is called once per frame
	void Update () {
		Physics2D.gravity = grav;//se encarga de actualizar el estado de gravedad en base a una variable que es modificada en cada sala (grav)
		camera.GetComponent<Camara2>().player=player;
	}
	void FixedUpdate() {
		if (!salaactual.GetComponent<GuardaGravedad> ().oxigeno)
			RestaOxigeno ();
		else
			AumentaOxigeno ();
		
		if(oxigeno>0) oxigenbar.GetComponent<RectTransform> ().localScale = new Vector3 (oxigeno / maxoxigeno, 1f, 1f);
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
		oxigeno = maxoxigeno;
	}
		
}
