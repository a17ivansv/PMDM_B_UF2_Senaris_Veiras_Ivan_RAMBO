using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject Bullet;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    public float JumpForce;
    public float Speed;
    public bool Grounded;
    private Animator Animator;
    private float LastShoot;

    [SerializeField] AudioClip sfxsalto;
    [SerializeField] AudioClip sfxdisparo;
    [SerializeField] AudioClip sfxrestarvida;
    [SerializeField] AudioClip sfxnomunicion;
    [SerializeField] AudioClip sfxrecargar;

    [SerializeField] AudioClip sfxgameover;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Horizontal<0)
        {
            transform.localScale = new Vector3(-1,1,1);

        }else if(Horizontal>0)
        {
            transform.localScale=new Vector3(1,1,1);
        }
        Animator.SetBool("Running",Horizontal !=0.0f);

        if(Physics2D.Raycast(transform.position,Vector3.down,0.1f))
        {
            Grounded = true;
        }else
        {
           Grounded =false; 
        }

        if(Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

         if(Input.GetKeyDown(KeyCode.Space) && Time.time> LastShoot+0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        AudioSource.PlayClipAtPoint(sfxsalto, new Vector3(0,0,-10),1);
    }

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

        if(GameManager.GetBalas()>0)
        {
            GameObject bullet = Instantiate(Bullet,transform.position + direction * 0.1f,Quaternion.identity);
            bullet.GetComponent<Bullet>().SetDireccion(direction);
            GameManager.RestartBalas();
            AudioSource.PlayClipAtPoint(sfxdisparo, new Vector3(0,0,-10),1);
        }else
        {
            AudioSource.PlayClipAtPoint(sfxnomunicion, new Vector3(0,0,-10),1);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed,Rigidbody2D.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
            if(other.tag =="Municion")
            {
                
                Destroy(other.gameObject);
                GameManager.Aprovisionar(10);
                AudioSource.PlayClipAtPoint(sfxrecargar, new Vector3(0,0,-10),1);

                
            }

            if(other.tag =="Disparo")
            {

                RestarVidaJugador();                
            }

            if(other.tag =="SiguienteNivel")
            {
                Scene escenaactual = SceneManager.GetActiveScene();
                if(escenaactual.buildIndex == 4)
                {
                    SceneManager.LoadScene(2);
                }else
                {
                    GameManager.SiguienteNivel = true;         
                }
            }

            if(other.tag == "LimiteInferior")
            {

                if(GameManager.GetVidas() > 1)
                {
                    RestarVidaJugador();
                    Scene escenaactual = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(escenaactual.buildIndex);
                }else
                {
                    Scene escenaactual = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(escenaactual.buildIndex);
                    AudioSource.PlayClipAtPoint(sfxgameover, new Vector3(0,0,-10),1);
                    GameManager.balastotales = 20;
                    GameManager.SetVidas(3);
                }

                
            }
    }

    void RestarVidaJugador()
    {
        GameManager.GetInstance().QuitarVida();
        AudioSource.PlayClipAtPoint(sfxrestarvida, new Vector3(0,0,-10),1);

    }


}
