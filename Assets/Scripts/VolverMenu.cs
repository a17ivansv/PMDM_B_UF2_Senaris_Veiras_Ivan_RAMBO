using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Cuando pulsamos en Volver, volvemos al Menú
    public void Click_BotonVolver()
    {
        SceneManager.LoadScene(0);
    }
}
