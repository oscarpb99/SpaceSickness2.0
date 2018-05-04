using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour {
	public Vector3 rotacion;

	void FixedUpdate () {
		if(GameManager.instance.salaactual==gameObject.GetComponent<EnemigoPlanta>().GetSala())
			gameObject.transform.Rotate (rotacion, Space.Self);
	}
		



}

