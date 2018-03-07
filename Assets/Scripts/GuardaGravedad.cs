using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaGravedad : MonoBehaviour {
	public float gravx;
	public float gravy;
	Vector2 gravedad;
	 


	void Awake(){
		 gravedad = new Vector2 (gravx, gravy);
		}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Physics2D.gravity = gravedad;
	}
}
