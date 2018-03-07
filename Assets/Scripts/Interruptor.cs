﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour {

    // Clase para guardar las funciones de objetos que se ejecutarán cuando se active el botón.
    class Observer
    {
        
        private MonoBehaviour monoBehaviour;    //Objeto con script que se activará al presionar el interruptor.
        private string enterFunction;           //Función del script anterior que se llamará al activarlo.
        private string exitFunction;            //Función del script anterior que se llamará al desactivar el interruptor. Parámetro opcional.

        public Observer(MonoBehaviour b, string enF, string exF = null)
        {
            monoBehaviour = b;
            enterFunction = enF;
            exitFunction = exF;
        }

        public MonoBehaviour GetMonoBehaviour()
        {
            return monoBehaviour;
        }
        public string GetEnterFunction()
        {
            return enterFunction;
        }

        public string GetExitFunction()
        {
            return exitFunction;
        }
    }

    List<Observer> observers;   //Lista de observadores que responderán al presionar el interruptor.
    Vector3 thisExtent;
    Vector3 thisPosition;
    public PruebaTrigger objeto;
    private GameObject currentObject;   // Objeto que está presionando el interruptor.
    public float onDelay;               // Lo que tardan en responder los objetos al presionar el interruptor.
    public float offDelay;              // Lo que tardan en responder los objetos al dejar de presionar el interruptor.

	// Use this for initialization
	void Start () {
        observers = new List<Observer>();
        thisExtent = gameObject.GetComponent<Collider2D>().bounds.extents;
        thisPosition = gameObject.transform.position;
        observers.Add(new Observer(objeto, "muestraOn", "muestraOff"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //La función detecta si el objeto ha colisionado con el botón desde arriba.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 extent = collision.collider.bounds.extents;
        Vector3 position = collision.transform.position;
        if (position.y - extent.y >= thisPosition.y + thisExtent.y - 0.1)
        {
            currentObject = collision.gameObject;
            foreach (Observer observer in observers)
            {
                observer.GetMonoBehaviour().Invoke(observer.GetEnterFunction(), onDelay);
            }
        }
    }

    //La función detecta si el objeto que está presionando el interruptor deja de hacerlo.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == currentObject)
        {
            currentObject = null;
            foreach (Observer observer in observers)
            {
                if (observer.GetExitFunction() != null)
                    observer.GetMonoBehaviour().Invoke(observer.GetExitFunction(), offDelay);
            }
        }
    }

    //Añade un observador.
    public void addObserver(MonoBehaviour b, string enF, string exF = null)
    {
        observers.Add(new Observer(b, enF, exF));
    }

    //Elimina un observador.
    public void deleteObserver(int i)
    {
        observers.RemoveAt(i);
    }
}

