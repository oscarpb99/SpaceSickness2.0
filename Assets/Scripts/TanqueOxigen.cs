﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanqueOxigen : MonoBehaviour {
	public float prAumentooxigen=1;//fraccion del maximo de oxigeno que se devuelve al consumir el tanque (1=maximo, 0=nada)
    public AudioSource aire;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			GameManager.instance.AumentaOxigeno (prAumentooxigen);
            aire.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled=false;
            Invoke("Activar", 1f);
		}
	}
    private void Activar()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
