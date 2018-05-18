using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinSala12 : MonoBehaviour {
	public GameObject enemigoPlanta1, enemigoPlanta2;
	Vector3 posEnePl1,posEnePl2;
	Quaternion rotEnePl1,rotEnePl2;


	void Start(){
		posEnePl1 = enemigoPlanta1.transform.position;
		posEnePl2 = enemigoPlanta2.transform.position;
		rotEnePl1 = enemigoPlanta1.transform.rotation;
		rotEnePl2 = enemigoPlanta2.transform.rotation;
	}
		
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "player") {
			enemigoPlanta1.transform.position = posEnePl1;
			enemigoPlanta2.transform.position = posEnePl2;
			enemigoPlanta1.transform.rotation = rotEnePl1;
			enemigoPlanta2.transform.rotation = rotEnePl2;
			
		}
	}
}
