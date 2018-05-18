using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicadorO2 : MonoBehaviour {
    public Image indicadorO2;

	void Update () {
        if (!GameManager.instance.salaactual.GetComponent<GuardaGravedad>().oxigeno)
            indicadorO2.enabled = true;
        else
            indicadorO2.enabled = false;		
	}
}
