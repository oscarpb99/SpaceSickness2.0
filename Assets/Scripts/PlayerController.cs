using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public bool controlmovimiento = false;
    Rigidbody2D rb;
    public Transform spawn;
    public GameObject playerprefab;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Quaternion currentRotation;
	public int fuerzapropulsion = 50;
	public float limitspeed = 10f;//límite de velocidad de propulsión en grav0
	public AudioClip pasos;
	public float volumen=1.0f;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.instance.oxigeno = GameManager.instance.maxoxigeno;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        //GameManager.instance.SetCurrentGravity(salaactual.GetComponent<GuardaGravedad>());


        if (GameManager.instance.oxigeno <= 0)
            Die();

        if (controlmovimiento)
            Movimiento();

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

    void Movimiento()
    {
		DireccionGravedad direccionActual = GameManager.instance.salaactual.GetComponent<GuardaGravedad>().GetDireccion();
		if (direccionActual == DireccionGravedad.Gravedad0) {
				float x = Input.GetAxis ("Horizontal");
				float y = Input.GetAxis ("Vertical");

				if (x > 0)
					x = 1;
				else if (x < 0)
					x = -1;
				if (y > 0)
					y = 1;
				else if (y < 0)
					y = -1;
			
				int propulsionx = 0;
				int propulsiony = 0;

				if (rb.velocity.x > -limitspeed && rb.velocity.x < limitspeed || rb.velocity.x <= -limitspeed && x > 0 || rb.velocity.x >= limitspeed && x < 0)//permitir la propulsión en el eje x si no se pasa del limite de velocidad
				propulsionx = 1;
			
				if (rb.velocity.y > -limitspeed && rb.velocity.y < limitspeed || rb.velocity.y <= -limitspeed && y > 0 || rb.velocity.y >= limitspeed && y < 0)////permitir la propulsión en el eje y si no se pasa del limite de velocidad
				propulsiony = 1;

				rb.AddForce (new Vector2 (x * propulsionx * fuerzapropulsion * Time.deltaTime, y * propulsiony * fuerzapropulsion * Time.deltaTime), ForceMode2D.Impulse);

				if (propulsionx == 1 && x != 0 || propulsiony == 1 && y != 0)
					GameManager.instance.PropulsaOxigeno ();
			}

		else {
			if (direccionActual == DireccionGravedad.Derecha)
			{
				transform.Translate (new Vector3 (Input.GetAxis ("Vertical") * speed * Time.deltaTime, 0, 0));

			} 
			else if (direccionActual == DireccionGravedad.Izquierda) 
			{
				transform.Translate (new Vector3 (-Input.GetAxis ("Vertical") * speed * Time.deltaTime, 0, 0));

			}
			else if (direccionActual == DireccionGravedad.Abajo)
			{
				transform.Translate (new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, 0));

		}
			else
			{
				transform.Translate (new Vector3 (-Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, 0));
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
				AudioSource.PlayClipAtPoint (pasos, this.gameObject.transform.position, volumen);
			} 
			else if (Input.GetKey (KeyCode.D)) {
				spriteRenderer.flipX = true;
				AudioSource.PlayClipAtPoint (pasos, this.gameObject.transform.position, volumen);
			}

                break;

		case DireccionGravedad.Abajo:
			spriteRenderer.transform.rotation = Quaternion.Euler (0, 0, 0);

			if (Input.GetKey (KeyCode.A)) {
				spriteRenderer.flipX = true;
				AudioSource.PlayClipAtPoint (pasos, this.gameObject.transform.position, volumen);
			}
			else if (Input.GetKey (KeyCode.D)) {
				spriteRenderer.flipX = false;
				AudioSource.PlayClipAtPoint (pasos, this.gameObject.transform.position, volumen);
			}

                break;

			case DireccionGravedad.Gravedad0:
				spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, 0);

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
				AudioSource.PlayClipAtPoint (pasos, this.gameObject.transform.position, volumen);
			}
			else if (Input.GetKey (KeyCode.S)) {
				spriteRenderer.flipX = false;
				AudioSource.PlayClipAtPoint (pasos, this.gameObject.transform.position, volumen);
			}

                break;

		case DireccionGravedad.Derecha:
			if (currentRotation.z == 0)
				spriteRenderer.transform.rotation = Quaternion.Euler (0, 0, 270f);
			else
				spriteRenderer.transform.rotation = Quaternion.Euler (0, 0, 90f);

			if (Input.GetKey (KeyCode.W)) {
				spriteRenderer.flipX = false;
				AudioSource.PlayClipAtPoint (pasos, this.gameObject.transform.position, volumen);
			} 
			else if (Input.GetKey (KeyCode.S)) {
				spriteRenderer.flipX = true;
				AudioSource.PlayClipAtPoint (pasos, this.gameObject.transform.position, volumen);
			}

                break;
        }

    }
		
}


	


