using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 2f;
	public bool controlmovimiento=false;
	GameObject salaactual= null;
	Rigidbody2D rb;
	public Transform spawn;
	public GameObject playerprefab;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		GameManager.instance.oxigeno = GameManager.instance.maxoxigeno;
	}
		

	void Update () {
        //GameManager.instance.SetCurrentGravity(salaactual.GetComponent<GuardaGravedad>());

		if (GameManager.instance.oxigeno<= 0)
			Die ();

        if (controlmovimiento)
		Movimiento ();

		if (Mathf.Abs (rb.velocity.x) <= 0.3f && Mathf.Abs (rb.velocity.y) <= 0.3f)
			rb.velocity = new Vector2 (0, 0);
	}
		
	void Movimiento () {
		salaactual = GameManager.instance.salaactual;
		if (salaactual.GetComponent<GuardaGravedad> ().GetDireccion() == DireccionGravedad.Derecha || salaactual.GetComponent<GuardaGravedad>().GetDireccion() == DireccionGravedad.Izquierda)
			transform.Translate (new Vector3 (0, Input.GetAxis ("Vertical") * speed * Time.deltaTime, 0));
		else transform.Translate(new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime,0, 0));
	}

	public void Die(){//método de muerte del jugador
		if (spawn != null) {
			GameObject spawned = Instantiate (playerprefab);
			spawned.transform.position = spawn.position;
		}
		Destroy(gameObject);
	}
		

}


	


