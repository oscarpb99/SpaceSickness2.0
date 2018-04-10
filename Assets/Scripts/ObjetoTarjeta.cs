using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoTarjeta : MonoBehaviour {

    public IdTarjeta id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            gameObject.SetActive(false);
            Tarjetas.instance.setOpen(id, true);
        }
    }
}
