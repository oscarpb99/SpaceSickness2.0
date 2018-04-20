using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    bool jugadorEnRango = false;
    bool zeroGravity;
    public Control control;
    private float m_lastPressed;
    public float margen = 0.5f;

    public enum Control
    {
        GRAVEDAD,
        OXIGENO
    }

    // Use this for initialization
    void Start()
    {
        m_lastPressed = Time.time;
        Invoke("startGravityCheck", margen);
    }

    private void FixedUpdate()
    {
        if (jugadorEnRango && Input.GetKeyDown(KeyCode.Space))
        {
            GravityCheck();
            if (m_lastPressed + margen <= Time.time)
            {
                m_lastPressed = Time.time;
                switch (control)
                {
                    case Control.GRAVEDAD:
                        if (!zeroGravity)
                            GameManager.instance.ZeroGravity();
                        else
                            GameManager.instance.ResetGravity();
                        zeroGravity = !zeroGravity;
                        break;
                    case Control.OXIGENO:
                        GameManager.instance.SwitchOxygen();
                        break;
                }
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

    private void GravityCheck()
    {
        zeroGravity = GameManager.instance.currentGravity.gravedadsala == Vector2.zero;
    }
}
