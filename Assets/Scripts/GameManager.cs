using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public enum DireccionGravedad
{
    Izquierda, Derecha, Arriba, Abajo, Gravedad0
}

public class GameManager : MonoBehaviour {
	public Vector2 grav;
	public static GameManager instance = null;
    public GuardaGravedad currentGravity;
	public GameObject salaactual;//sala donde se encuentra el jugador
	public float oxigeno;//cantidad de oxigeno restante en el tanque del jugador
	public float maxoxigeno=600;
	public GameObject oxigenbar;
    public IndicadorGravedad indicador;
	public float gastoxigen=0.01f;
	GameObject camerapos;
	GameObject ultimasala=null;

	void Awake(){
		instance = this;

	}
		
	// Update is called once per frame
	void Update () {
		if(salaactual!=null)
		Physics2D.gravity = salaactual.GetComponent<GuardaGravedad>().gravedadsala;//se encarga de actualizar el estado de gravedad en base a una variable que es modificada en cada sala (grav)
	}
	void FixedUpdate() {
		if (salaactual != null&& oxigenbar!=null) {
			if (!salaactual.GetComponent<GuardaGravedad> ().oxigeno && salaactual.GetComponent<GuardaGravedad>().GetDireccion()!=DireccionGravedad.Gravedad0)
				RestaOxigeno ();
			else if(salaactual.GetComponent<GuardaGravedad>().oxigeno)
				AumentaOxigeno (1);
		
			if (oxigeno > 0)
				oxigenbar.GetComponent<RectTransform> ().localScale = new Vector3 (oxigeno / maxoxigeno, 1f, 1f);
		}
	}
    public DireccionGravedad GetDirection()
    {
        return currentGravity.GetDireccion();
    }

    public void SetCurrentGravity(GuardaGravedad g)
    {
        currentGravity = g;
    }

	void RestaOxigeno() {
		oxigeno--;
	}

	public void PropulsaOxigeno(){
		oxigeno = oxigeno - maxoxigeno * gastoxigen;
	}

	public void AumentaOxigeno(float cantidad){
		if (oxigeno + cantidad * maxoxigeno > maxoxigeno)
			oxigeno = maxoxigeno;
		else
			oxigeno = oxigeno + cantidad * maxoxigeno;
	}

	public void ReiniciaSala(){
		salaactual.GetComponent<GuardaGravedad> ().ResetGravity();
		salaactual.GetComponent<GuardaGravedad> ().ResetOxigeno ();
		int i = 0;
		GameObject[]objetosala=salaactual.GetComponent<GuardaGravedad>().GetObjetos();
		while (i<objetosala.Length && objetosala [i] != null) {
			objetosala [i].GetComponent<SleepObjetos> ().ReseteaPosicion ();
			i++;
		}

	}

	public GameObject GetCamerapos(){
		return camerapos;
	}

	public void SetCamerapos(GameObject Camerapos){
		camerapos = Camerapos;
	}

	public void SetUltimaSala(GameObject sala){
		ultimasala = sala;
	}

	public GameObject GetUltimaSala(){
		return ultimasala;
	}

    public void ZeroGravity()
    {
        currentGravity.ZeroGravity();
    }

    public void ResetGravity()
    {
        currentGravity.ResetGravity();
    }

    public void SwitchOxygen()
    {
        currentGravity.oxigeno = !currentGravity.oxigeno;
    }

}
