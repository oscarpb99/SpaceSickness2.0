using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaTrigger : MonoBehaviour {
    public bool muestra; 
	// Use this for initialization
	void Start () {
        muestra = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void muestraOn()
    {
        muestra = true;
    }

    public void muestraOff()
    {
        muestra = false;
    }
}
