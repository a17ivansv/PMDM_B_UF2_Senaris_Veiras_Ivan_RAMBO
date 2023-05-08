using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Numero total de vidas con el que empiezo la partida, en total 3, con la que empiezo y 2 más

    public static GameManager instancia;

 
    public static int vidastotales = 3;
    public static int balastotales = 20;

    public static bool SiguienteNivel = false;

    [SerializeField] GameObject jugador;
    [SerializeField] AudioClip sfxgameover;
    [SerializeField] Text mensagegameover;

    public static Image[] vidas;
    public static Text balas;

   public static bool gameover;

    public static GameManager GetInstance()
    {
        return instancia;
    }
    //Awake, se invoca siempre independientemente de si el componente está habilitado o no, esta es la difrencia con Start que solo se ejecuta si el componente está habilitado
    void Awake()
    {
        if(instancia ==null)
        {
            //Asignamos la referencia
            instancia = this;
            //Para evitar su destruccion al cargar la nueva escena 
            //DontDestroyOnLoad(gameObject);

        }else if(instancia != this)
        {
            Destroy(gameObject);
        }

    }



    //Metodo publico para controlar si la partida ha finalizado o no
    public static bool isGameOver()
    {
        return gameover;
    }

    //Metodo publico
    public void QuitarVida()
    {
        vidastotales--;
        if(vidastotales ==0)
        {
            //Finalizo la partida llamando a la función que realiza dicha tarea
            GameOver();
            
        }
    }

    public static void SetVidas(int vidasnuevas)
    {
        vidastotales=vidasnuevas;
    }


    public void GameOver()
    {
        gameover = true;
        AudioSource.PlayClipAtPoint(sfxgameover, new Vector3(0,0,-10),1);
        mensagegameover.enabled = true;
        mensagegameover.text = "GAME OVER\n PRESS <RET> TO RESTART";
        Destroy(jugador);
    }

    private void Update()
    {
        if(gameover && Input.GetKeyDown(KeyCode.Return))
        {
            gameover = false;
            Scene escenaactual = SceneManager.GetActiveScene();
            SceneManager.LoadScene(escenaactual.buildIndex);
            vidastotales=3;
            balastotales = 20;

        }

        if(SiguienteNivel)
        {
            SceneManager.LoadScene(4);
            vidastotales=3;
            balastotales = 20;
            SiguienteNivel = false;
        }
    }

    public static int GetVidas()
    {
        return vidastotales;
    }

    public static int GetBalas()
    {
        return balastotales;
    }

    public static void RestartBalas()
    {
        balastotales--;
    }

    public static void Aprovisionar(int numerobalas)
    {
        balastotales = balastotales + numerobalas;
    }


}
