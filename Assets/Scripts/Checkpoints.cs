using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {
	public bool activated=false;
	public static GameObject[] CheckPointsList;
	public static Checkpoints lastCheck;

	// Use this for initialization
	void Start () {
		CheckPointsList = GameObject.FindGameObjectsWithTag ("CheckPoints");

	}

	// Update is called once per frame
	void Update () {

	}
	public static Vector3 ActivateCheckPoints(Checkpoints check = null)
	{
		if (check == null)
			check = lastCheck;
		foreach (GameObject cp in CheckPointsList) 
		{
			cp.GetComponent<Checkpoints>().activated = false;
			cp.SetActive (false);

		}
		lastCheck = check;
		check.activated = true;
		return lastCheck.transform.position;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			ActivateCheckPoints (this);
		}
	}
}

