using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {
	bool pause=false;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p") && pause == false) 
		{
			pause = true;
			Time.timeScale = 0;
		}
		else if (Input.GetKeyDown ("p") && pause == true) 
		{
			pause = false;
			Time.timeScale = 1;
		}
		
	}
}
