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
	}

    public DireccionGravedad GetDirection()
    {
        return currentGravity.GetDireccion();
    }

    public void SetCurrentGravity(GuardaGravedad g)
    {
        currentGravity = g;
    }
}
