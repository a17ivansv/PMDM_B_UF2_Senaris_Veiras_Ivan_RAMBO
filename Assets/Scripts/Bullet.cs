using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Declaramos las variables
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direccion;
    
    [SerializeField] float Velocidad;

    //Función que se ejecuta solo una vez al iniciar el objeto que llama al script
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //Función que se ejecuta en cada frame pero con un tiempo fijo entre frames
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direccion * Velocidad;    
    }

    //Función que establece la dirección de la bala en función de la direccion del usuarios que la instancia
    public void SetDireccion(Vector2 parametro)
    {
        Direccion = parametro;
    }

    //Función que destruye la bala instanciada
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    //Función que nos permite conocer con quien colisiona la bala si con el personaje principal o con el enemigo
    private void OnTriggerEnter2D(Collider2D other)        
    {
        Player player= other.GetComponent<Player>();
        Enemigo enemigo= other.GetComponent<Enemigo>(); 

        if(enemigo!=null)
        {
            enemigo.Hit();
        }

        DestroyBullet();
    }


    
}
