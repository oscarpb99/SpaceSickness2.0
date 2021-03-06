﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IdTarjeta
{
    NO_TARJETA = 0,
    ROJA = 1,
	AZUL = 2,
	VIOLETA=3,
}

public class Tarjetas : MonoBehaviour {
    public static Tarjetas instance = null;
    private const uint numTarjetas = 3;
    private bool[] estadoTarjetas = new bool[numTarjetas];

    void Awake()
    {
         instance = this;
        
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    public bool getOpen(IdTarjeta id)
    {
        if ((uint)id > 0 && (uint)id <= numTarjetas)
            return estadoTarjetas[(uint)id - 1];
        else return false;

    }

    public void setOpen(IdTarjeta id, bool estado)
    {
        if ((uint)id > 0 && (uint)id <= numTarjetas)
            estadoTarjetas[(uint)id - 1] = estado;
    }
}

