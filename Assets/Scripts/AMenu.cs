using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AMenu : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene ("Menu");
		}
	}
}
