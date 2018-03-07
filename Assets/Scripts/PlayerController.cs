using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 2f;
	GameObject salaactual;

	void Update () {
		salaactual = this.GetComponentInChildren<CambioGravedad> ().sala;
		if (salaactual.GetComponent<GuardaGravedad> ().Direccion == "derecha")
			transform.Translate (new Vector3 (0, Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0));
		else if (salaactual.GetComponent<GuardaGravedad> ().Direccion == "izquierda")
			transform.Translate (new Vector3 (0, Input.GetAxis ("Horizontal") * -speed * Time.deltaTime, 0));
		else transform.Translate(new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime,0, 0));
				
	}

}


	


