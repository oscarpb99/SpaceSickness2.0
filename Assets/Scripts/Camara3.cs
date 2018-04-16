using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara3 : MonoBehaviour {
	GameObject camera;

	void Update(){
		camera = GameManager.instance.GetCamerapos ();
		gameObject.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, -10);
		gameObject.GetComponent<Camera> ().orthographicSize = 5*camera.GetComponent<ConfiguracionCamara> ().zoom;
	
	}


}
