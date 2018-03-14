using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour {
	public GameObject gb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Dead()
	{
		DestroyImmediate(gb);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "enemy"||col.gameObject.tag=="Bad Floor") {
			Instantiate (gb,Checkpoints.lastCheck.transform);
			Dead ();

			
		}
	}
}
