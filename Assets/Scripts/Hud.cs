using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour {
	public static Hud instance = null;
	public GameObject t_roj;
	public GameObject t_azul;
	public GameObject t_vio;

	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	// Update is called once per frame
	void Start(){
		t_roj.SetActive (false);
		t_azul.SetActive (false);
		t_vio.SetActive (false);
	}

	public void SetTarjeta(IdTarjeta id){
		switch (id) {
		case IdTarjeta.ROJA:
			t_roj.SetActive (true);
			break;
		case IdTarjeta.AZUL:
			t_azul.SetActive (true);
			break;
		case IdTarjeta.VIOLETA:
			t_vio.SetActive (true);
			break;
		default:
			break;
		}
	}
}
