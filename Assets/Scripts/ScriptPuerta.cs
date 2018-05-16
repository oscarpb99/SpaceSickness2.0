using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPuerta : MonoBehaviour {
	public bool bloqueada;
	bool abierta=false;
	int contador;
	public bool jugadorEnRango=false;
	public GameObject collider;
	Animator anim;
    public IdTarjeta id;
	public AudioSource puertaDesbloq;
	public AudioSource puertaBloq;
	
	void Start(){
		anim = GetComponent<Animator> ();
	}


	void FixedUpdate () {
        if (id == IdTarjeta.NO_TARJETA && !bloqueada)
        {
            Abrir();
        }
        else if (id != IdTarjeta.NO_TARJETA && Tarjetas.instance.getOpen(id))
            Abrir();
        else
            abierta = false;

		AbreCierra ();
		Animaciones ();
	}

	void AbreCierra(){
		collider.GetComponent<BoxCollider2D> ().enabled = !abierta;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			jugadorEnRango = true;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			jugadorEnRango = false;
		}

	}

	void Desbloquear(){
		bloqueada = false;
		puertaDesbloq.Play ();
	}

	void Bloquear(){
		bloqueada = true;
		puertaBloq.Play();
	}

	void Animaciones(){
		if (bloqueada)
			anim.SetInteger ("State", 2);
		else {
			if (abierta)
				anim.SetInteger ("State", 1);
			else
				anim.SetInteger ("State", 0);
		}
	}

    void Abrir()
    {
        if (!abierta && Input.GetKeyDown(KeyCode.Space))
        {
            if (jugadorEnRango)
            {
                abierta = true;
                contador = 100;
            }
        }
        else
        {
			if (contador <= 0 && !jugadorEnRango)
                abierta = false;
            else
                contador--;
        }
    }
}
		
