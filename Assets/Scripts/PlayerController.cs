using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 2f;

	void Update () {
		transform.Translate (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, 0);
	}
	public static Vector2 GetActiveCheckPointPosition ()
	{
		Vector2 result = new Vector2 (0, 0);
		if (Checkpoints.CheckPointsList != null) {
			foreach (GameObject cp in Checkpoints.CheckPointsList) {
				if (cp.GetComponent<Checkpoints>().activated) {
					result = cp.transform.position;
					break;
				}
			}
		}
		return result;
	}
}
