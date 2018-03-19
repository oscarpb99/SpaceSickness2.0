using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IndicadorGravedad : MonoBehaviour
{
    public Sprite izquierdaDesactivado;
    public Sprite izquierdaActivado;
    public Sprite derechaDesactivado;
    public Sprite derechaActivado;
    public Sprite arribaDesactivado;
    public Sprite arribaActivado;
    public Sprite abajoDesactivado;
    public Sprite abajoActivado;

    private Image[] images;

    // Use this for initialization
    void Start () {
        GameManager.instance.indicador = this;
        images = gameObject.GetComponentsInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void updateButtons(GuardaGravedad g)
    {
        if (g.gravizquierda)
            images[0].sprite = izquierdaActivado;
        else images[0].sprite = izquierdaDesactivado;
        if (g.gravderecha)
            images[1].sprite = derechaActivado;
        else images[1].sprite = derechaDesactivado;
        if (g.gravarriba)
            images[2].sprite = arribaActivado;
        else images[2].sprite = arribaDesactivado;
        if (g.gravabajo)
            images[3].sprite = abajoActivado;
        else images[3].sprite = abajoDesactivado;
    }
}
