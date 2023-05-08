using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    public AudioSource sonido;

    void Start()
    {
        
    }

    //Función que se llama en cada frame la cual hace que la camara siga al personaje
    void Update()
    {
        if(Player!=null)
        {
            Vector3 position = transform.position;
            position.x = Player.transform.position.x;
            transform.position = position;
        }

        if(PausarJuego.estapausado)
        {
            sonido.Pause();
        }else
        {
            sonido.UnPause();
        }

    }
}
