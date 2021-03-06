﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 0.9f;
	public bool controlmovimiento = false;
	Rigidbody2D rb;
	public Transform spawn;
	public GameObject playerprefab;
	Animator animator;
	SpriteRenderer spriteRenderer;
	Quaternion currentRotation;
	public int fuerzapropulsion = 50;
	public float limitspeed = 10f;//límite de velocidad de propulsión en grav0
	public AudioSource pasos;
	public float volumen=1.0f;
	public float deceleraciongrav0=0.1f;




	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		GameManager.instance.oxigeno = GameManager.instance.maxoxigeno;
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		animator = GetComponentInChildren<Animator>();
		rb.velocity = new Vector2(0, -0.1f);
	}


	void Update()
    {

        if (GameManager.instance.oxigeno <= 0)
			Die();

		/* if (Mathf.Abs(rb.velocity.x) <= 0.3f && Mathf.Abs(rb.velocity.y) <= 0.3f)
            rb.velocity = new Vector2(0, 0);
            */

		if (Input.GetKey(KeyCode.R))
		{
			gameObject.transform.position = spawn.position;
			GameManager.instance.ReiniciaSala();
		}

		SpriteFlip();
	}

    private void FixedUpdate()
    {
        Falling();

        if (controlmovimiento)
            Movimiento();
    }

    void Movimiento()
	{
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        DireccionGravedad direccionActual = GameManager.instance.salaactual.GetComponent<GuardaGravedad>().GetDireccion();
		if (direccionActual == DireccionGravedad.Gravedad0) {
			

			int propulsionx = 0;
			int propulsiony = 0;


			if (rb.velocity.x > -limitspeed && rb.velocity.x < limitspeed || rb.velocity.x <= -limitspeed && x > 0 || rb.velocity.x >= limitspeed && x < 0)//permitir la propulsión en el eje x si no se pasa del limite de velocidad
				propulsionx = 1;

			if (rb.velocity.y > -limitspeed && rb.velocity.y < limitspeed || rb.velocity.y <= -limitspeed && y > 0 || rb.velocity.y >= limitspeed && y < 0)////permitir la propulsión en el eje y si no se pasa del limite de velocidad
				propulsiony = 1;

			rb.AddForce (new Vector2 (x * propulsionx * fuerzapropulsion * Time.deltaTime, y * propulsiony * fuerzapropulsion * Time.deltaTime), ForceMode2D.Impulse);

			if (propulsionx == 1 && x != 0 || propulsiony == 1 && y != 0)
				GameManager.instance.PropulsaOxigeno ();
			if (x == 0)
				rb.velocity = new Vector2 (rb.velocity.x-rb.velocity.x*deceleraciongrav0, rb.velocity.y);
			if(y==0)
				rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y-rb.velocity.y*deceleraciongrav0);
		}

		else {
			if (direccionActual == DireccionGravedad.Derecha)
			{
				rb.velocity = new Vector2(0, y * speed);

			} 
			else if (direccionActual == DireccionGravedad.Izquierda)
			{
				rb.velocity = new Vector2(0, y * speed);

			}
			else if (direccionActual == DireccionGravedad.Abajo)
			{
				rb.velocity = new Vector2(x * speed, 0);
			}
			else
			{

				rb.velocity = new Vector2(x * speed, 0);
			}
		}
	}

	public void Die()
	{//método de muerte del jugador
		if (spawn != null)
		{
			GameObject spawned = Instantiate(playerprefab);
			spawned.transform.position = spawn.position;
			GameManager.instance.ReiniciaSala();
		}
		Destroy(gameObject);
	}

	void Falling()
	{
		DireccionGravedad direccionActual = GameManager.instance.salaactual.GetComponent<GuardaGravedad>().GetDireccion();
		if (direccionActual == DireccionGravedad.Abajo && rb.velocity.y < 0 || 
			direccionActual == DireccionGravedad.Arriba && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
			controlmovimiento = false;
		}
		else if(direccionActual == DireccionGravedad.Izquierda && rb.velocity.x < 0 ||
			direccionActual == DireccionGravedad.Derecha && rb.velocity.x > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
			controlmovimiento = false;
		}
        else
        {
            controlmovimiento = true;
        }
	}

	public void SpriteFlip()
	{
		currentRotation = spriteRenderer.transform.rotation;
		DireccionGravedad direccionActual = GameManager.instance.salaactual.GetComponent<GuardaGravedad>().GetDireccion();

		if ((direccionActual == DireccionGravedad.Arriba || direccionActual == DireccionGravedad.Abajo) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
			animator.SetBool("movimiento", true);
		else if ((direccionActual == DireccionGravedad.Derecha || direccionActual == DireccionGravedad.Izquierda) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
			animator.SetBool("movimiento", true);
		else
			animator.SetBool("movimiento", false);

		switch (direccionActual) // flip en las 4 direcciones segun la gravedad
		{
		case DireccionGravedad.Arriba:
			spriteRenderer.transform.rotation = Quaternion.Euler (0, 0, 180f);

			if (Input.GetKey (KeyCode.A)) {
				spriteRenderer.flipX = false;
			} 
			else if (Input.GetKey (KeyCode.D)) {
				spriteRenderer.flipX = true;
			}
			if ((Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D))&&controlmovimiento) {
				pasos.loop = true;
				pasos.Play ();
			}
			else if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)||!controlmovimiento){
				pasos.Stop ();
			}


			break;

		case DireccionGravedad.Abajo:
			spriteRenderer.transform.rotation = Quaternion.Euler (0, 0, 0);

			if (Input.GetKey (KeyCode.A)) {
				spriteRenderer.flipX = true;
			} 
			else if (Input.GetKey (KeyCode.D)) {
				spriteRenderer.flipX = false;
			}
			if ((Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D))&&controlmovimiento) {
				pasos.loop = true;
				pasos.Play ();
			}
			else if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)||!controlmovimiento){
				pasos.Stop ();
			}

			break;

		case DireccionGravedad.Gravedad0:
			spriteRenderer.transform.rotation = Quaternion.Euler (0, 0, 0);
			pasos.Stop ();
			if (Input.GetKey(KeyCode.A))
				spriteRenderer.flipX = true;
			else if (Input.GetKey(KeyCode.D))
				spriteRenderer.flipX = false;
			break;

		case DireccionGravedad.Izquierda:
			if (currentRotation.z == 0)
				spriteRenderer.transform.rotation = Quaternion.Euler (0, 0, 90f);
			else
				spriteRenderer.transform.rotation = Quaternion.Euler (0, 0, 270f);

			if (Input.GetKey (KeyCode.W)) {
				spriteRenderer.flipX = true;
			} else if (Input.GetKey (KeyCode.S)) {
				spriteRenderer.flipX = false;

			}
			if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S)) &&controlmovimiento) {
				pasos.loop = true;
				pasos.Play ();
			} 
			else if(Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.S)||!controlmovimiento){
				pasos.Stop ();
			}

			break;

		case DireccionGravedad.Derecha:
			if (currentRotation.z == 0)
				spriteRenderer.transform.rotation = Quaternion.Euler (0, 0, 270f);
			else
				spriteRenderer.transform.rotation = Quaternion.Euler (0, 0, 90f);

			if (Input.GetKey (KeyCode.W)) {
				spriteRenderer.flipX = false;
			} 
			else if (Input.GetKey (KeyCode.S)) {
				spriteRenderer.flipX = true;
			}
			if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S))&&controlmovimiento) {
				pasos.loop = true;
				pasos.Play ();
			}
			else if(Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.S)||!controlmovimiento){
				pasos.Stop ();
			}

			break;
		}

	}

}


	


