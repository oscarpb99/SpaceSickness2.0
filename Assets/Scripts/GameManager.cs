using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Vector2 grav;
	public static GameManager instance = null;

	void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else
			Destroy (this.gameObject);
	}
		
	
	// Update is called once per frame
	void Update () {
		Physics2D.gravity = grav;//se encarga de actualizar el estado de gravedad en base a una variable que es modificada en cada sala (grav)
	}
}
