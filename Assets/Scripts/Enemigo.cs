using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    //Declaro e inicializo las variables necesarias
    public GameObject Player;
    public GameObject Bullet;
    private float LastShoot;
    private int vida=3;
    [SerializeField] int recorrido;


    //Función que se llama una vez en cada frame (esto puede variar en función de la potencia de la maquina)
    void Update()
    {
        if(Player==null)
        {
            return;
        }

        Vector3 direccion = Player.transform.position - transform.position;
        if(direccion.x >=0)
        {
            transform.localScale=new Vector3(1,1,1);
        }else
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        float distancia = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if(distancia < 0.8 && Time.time > LastShoot + 0.25)
        {
            Shoot();
            LastShoot = Time.time;
        }

    }

    //Función disparo que instancia la bala
    private void Shoot()
    {
        Vector3 direction;
        if(transform.localScale.x == 1)
        {
            direction = Vector2.right;
        }else
        {
            direction = Vector2.left;
        }
        GameObject bullet = Instantiate(Bullet,transform.position + direction * 0.1f,Quaternion.identity);
        
        bullet.GetComponent<Bullet>().SetDireccion(direction);
    }

    //Función que resta 1 vida al Enemigo y si el contador de vidas llega a cero entonces destruye el objeto
    public void Hit()
    {
        vida=vida-1;
        {
            if(vida==0)
            {
                Destroy(gameObject);
            }
        }
    }

}
