using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour {
	bool pause=false;
	public GameObject PauseMenu;
	public PlayerController player;
	PlayerController x;
	void Start(){
		x = player.GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) 
		{
			pause = !pause;
		}

		if (pause) {
			PauseMenu.SetActive (true);
			Time.timeScale = 0;
			x.enabled = false;



		} else {
			PauseMenu.SetActive (false);
			Time.timeScale = 1;
			x.enabled=true;
		}
		
	}
	public void Resume(){
		PauseMenu.SetActive (false);
		pause = false;
		Time.timeScale = 1;
		x.enabled = true;
		}
	public void QuitGame(){
		SceneManager.LoadScene("Menu");
		pause = false;
		x.enabled = true;
	}
}
