using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUIController : MonoBehaviour
{


    [SerializeField] Image[] vidas;

    [SerializeField] Text balas;



    public void OnGUI()
    {
        //Activar los iconos de las vidas
        for(int i = 0;i<vidas.Length;i++)
        {
            vidas[i].enabled = i < GameManager.vidastotales-1;
        }

        balas.text = GameManager.balastotales.ToString();
        

    }





}
