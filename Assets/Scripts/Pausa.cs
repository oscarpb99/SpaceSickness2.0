using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour {
	bool pause=false;
	public GameObject PauseMenu;


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) 
		{
			pause = !pause;
		}

		if (pause) {
			PauseMenu.SetActive (true);
			Time.timeScale = 0;
		} else {
			PauseMenu.SetActive (false);
			Time.timeScale = 1;
		}
		
	}
	public void Resume(){
		PauseMenu.SetActive (false);
		pause = false;
		Time.timeScale = 1;
		}
	public void QuitGame(){
		SceneManager.LoadScene("Menu");
		pause = false;
	}
}
