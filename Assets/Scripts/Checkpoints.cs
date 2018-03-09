using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {
	public bool activated=false;
	public static GameObject[] CheckPointsList;

	// Use this for initialization
	void Start () {
		CheckPointsList = GameObject.FindGameObjectsWithTag ("CheckPoints");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 public void ActivateCheckPoints()
	{
		foreach (GameObject cp in CheckPointsList) 
		{
			cp.GetComponent<Checkpoints>().activated = false;
			cp.GetComponent<GameObject> ().SetActive (false);

		}
		activated = true;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			ActivateCheckPoints ();
		}
	}
}
