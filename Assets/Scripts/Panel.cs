using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    bool jugadorEnRango = false;
    bool zeroGravity = false;
    public Control control;

    public enum Control
    {
        GRAVEDAD,
        OXIGENO
    }

    // Use this for initialization
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (jugadorEnRango && Input.GetKey(KeyCode.Space))
        {
            switch (control)
            {
                case Control.GRAVEDAD:
                    if (zeroGravity)
                        GameManager.instance.ZeroGravity();
                    else
                        GameManager.instance.ResetGravity();
                    zeroGravity = !zeroGravity;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            jugadorEnRango = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            jugadorEnRango = false;
        }

    }
}
