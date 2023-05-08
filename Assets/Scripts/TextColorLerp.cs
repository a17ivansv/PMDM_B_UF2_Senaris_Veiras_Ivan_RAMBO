using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorLerp : MonoBehaviour
{

    //Referencia al campo texto al que voy a modificar el color 
    [SerializeField] Text mensaje;
    //Duración de la corroutina desde el inicio al final (es decir el tiempo que durara)
    [SerializeField] float duracion;


    void Start()
    {
        //Lanzo una corroutina que cambiara el color
        StartCoroutine("CambiarColor");
    }

    IEnumerator CambiarColor()
    {
        //Valor de duracion inicial
        float inicial = 0;
        while(inicial < duracion)
        {
            inicial += Time.deltaTime;
            mensaje.color = Color.Lerp(Color.black, Color.white, inicial/duracion);
            //Detenemos la corroutina y esperamos al siguiente frame de ejecucion
            yield return null;
        }

        //Reiniciamos la corroutina
        StartCoroutine("CambiarColor");
    }
}
