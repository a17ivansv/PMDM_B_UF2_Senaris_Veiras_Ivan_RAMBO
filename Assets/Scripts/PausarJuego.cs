using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarJuego : MonoBehaviour
{

    public static bool estapausado = false;
    public GameObject menupausa;

    void Start()
    {
        estapausado = false; 
        menupausa.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(estapausado)
            {
                Continuar();
            }else
            {
                Pausar();
            }
        }
    }

    public void Continuar()
    {
        menupausa.SetActive(false);
        Time.timeScale = 1f;
        estapausado = false;
    }

    public void Pausar()
    {
        menupausa.SetActive(true);
        //Freezeamos el juego
        Time.timeScale = 0f;
        estapausado = true;
    }

    public void CargarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
