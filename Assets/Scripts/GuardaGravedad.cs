using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaGravedad : MonoBehaviour {
	public bool gravarriba;//restriccion de habilidad de cambiar la gravedad en cualquiera de las 4 direcciones
	public bool gravabajo;
	public bool gravderecha;
	public bool gravizquierda;
	public Vector2 gravedadsala;//guarda la direccion de la gravedad propia de la sala
	public string Direccion;

	void Update(){
		if (gravedadsala.x < 0)
			Direccion = "izquierda";
		else if (gravedadsala.x > 0)
			Direccion = "derecha";
		else if (gravedadsala.y > 0)
			Direccion = "arriba";
		else if  (gravedadsala.y < 0)
			Direccion = "abajo";
	}
	 




}
