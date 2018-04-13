using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public bool controlmovimiento = false;
    GameObject salaactual = null;
    Rigidbody2D rb;
    public Transform spawn;
    public GameObject playerprefab;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Quaternion currentRotation;




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

        if (Mathf.Abs(rb.velocity.x) <= 0.3f && Mathf.Abs(rb.velocity.y) <= 0.3f)
            rb.velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.R))
        {
            gameObject.transform.position = spawn.position;
            GameManager.instance.ReiniciaSala();
        }

        SpriteFlip();

    }

    void Movimiento()
    {
        salaactual = GameManager.instance.salaactual;
        if (salaactual.GetComponent<GuardaGravedad>().GetDireccion() == DireccionGravedad.Derecha || salaactual.GetComponent<GuardaGravedad>().GetDireccion() == DireccionGravedad.Izquierda)
            transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0));
        else transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
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

        DireccionGravedad direccionActual = salaactual.GetComponent<GuardaGravedad>().GetDireccion();



        if ((direccionActual == DireccionGravedad.Arriba || direccionActual == DireccionGravedad.Abajo) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            animator.SetBool("movimiento", true);
        else if ((direccionActual == DireccionGravedad.Derecha || direccionActual == DireccionGravedad.Izquierda) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            animator.SetBool("movimiento", true);
        else
            animator.SetBool("movimiento", false);

        switch (direccionActual) // flip en las 4 direcciones segun la gravedad
        {
            case DireccionGravedad.Arriba:
                spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, 180f);

                if (Input.GetKeyDown(KeyCode.A))
                    spriteRenderer.flipX = false;
                else if (Input.GetKeyDown(KeyCode.D))
                    spriteRenderer.flipX = true;

                break;

            case DireccionGravedad.Abajo:
                spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, 0);

                if (Input.GetKeyDown(KeyCode.A))
                    spriteRenderer.flipX = true;
                else if (Input.GetKeyDown(KeyCode.D))
                    spriteRenderer.flipX = false;

                break;

            case DireccionGravedad.Izquierda:
                if (currentRotation.z == 0)
                    spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, 90f);
                else
                    spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, 270f);

                if (Input.GetKeyDown(KeyCode.W))
                    spriteRenderer.flipX = true;
                else if (Input.GetKeyDown(KeyCode.S))
                    spriteRenderer.flipX = false;

                break;

            case DireccionGravedad.Derecha:
                if (currentRotation.z == 0)
                    spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, 270f);
                else
                    spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, 90f);

                if (Input.GetKeyDown(KeyCode.W))
                    spriteRenderer.flipX = false;
                else if (Input.GetKeyDown(KeyCode.S))
                    spriteRenderer.flipX = true;

                break;
        }
    }
}


	


