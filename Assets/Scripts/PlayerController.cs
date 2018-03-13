using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 2f;
	public bool controlmovimiento=false;
	GameObject salaactual= null;
	Rigidbody2D rb;


	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
        //GameManager.instance.SetCurrentGravity(salaactual.GetComponent<GuardaGravedad>());
		if(salaactual!=null) GameManager.instance.salaactual=salaactual;

        if (controlmovimiento)
		Movimiento ();

		if (Mathf.Abs (rb.velocity.x) <= 0.3f && Mathf.Abs (rb.velocity.y) <= 0.3f)
			rb.velocity = new Vector2 (0, 0);
	}
		
	void Movimiento () {
		salaactual = this.GetComponent<CambioGravedad> ().sala;
		if (salaactual.GetComponent<GuardaGravedad> ().GetDireccion() == DireccionGravedad.Derecha)
			transform.Translate (new Vector3 (0, Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0));
		else if (salaactual.GetComponent<GuardaGravedad>().GetDireccion() == DireccionGravedad.Izquierda)
			transform.Translate (new Vector3 (0, Input.GetAxis ("Horizontal") * -speed * Time.deltaTime, 0));
		else transform.Translate(new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime,0, 0));
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "enemy")//cuando colisiona con un enemigo
			Die ();
	}

	void Die(){//método de muerte del jugador
		Destroy (gameObject);
	}
		
/*
	public static Vector2 GetActiveCheckPointPosition ()
	{
		Vector2 result = new Vector2 (0, 0);
		if (Checkpoints.CheckPointsList != null) {
			foreach (GameObject cp in Checkpoints.CheckPointsList) {
				if (cp.GetComponent<Checkpoints>().activated) {
					result = cp.transform.position;
					break;
				}
			}
		}
		return result;
	}*/

}


	


