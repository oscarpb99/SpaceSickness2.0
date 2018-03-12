using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 2f;
	public bool controlmovimiento=false;
	GameObject salaactual;
	Rigidbody2D rb;


	void Awake () {
		rb = GetComponentInChildren<Rigidbody2D> ();
	}
	void Update () {
		if(controlmovimiento)
		Movimiento ();

		if (Mathf.Abs (rb.velocity.x) <= 0.3f && Mathf.Abs (rb.velocity.y) <= 0.3f)
			rb.velocity = new Vector2 (0, 0);
	}

	void Movimiento () {
		salaactual = this.GetComponentInChildren<CambioGravedad> ().sala;
			transform.Translate (new Vector3 (0, Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0));
			transform.Translate (new Vector3 (0, Input.GetAxis ("Horizontal") * -speed * Time.deltaTime, 0));
		else transform.Translate(new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime,0, 0));
	}






}


	


