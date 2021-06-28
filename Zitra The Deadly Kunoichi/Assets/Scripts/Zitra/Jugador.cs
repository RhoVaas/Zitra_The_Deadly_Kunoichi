using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    public float velocidad;
    private bool Grounded;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private float LastAtaque;
    private float Horizontal;
    int saltosHechos;
    int limiteSaltos = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        saltosHechos = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        animator.SetBool("estaCorriendo", Horizontal != 0.0f);
        if (Time.time > LastAtaque + 1.0f) animator.SetBool("estaAtacando", false);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(saltosHechos < limiteSaltos){
            Salto();
            saltosHechos++;
            }

        } 
        
        if (Input.GetKeyDown(KeyCode.X) && Time.time > LastAtaque + 1f)
        {
            Ataque();
            LastAtaque = Time.time;
        }


    }


    private void Salto(){
        animator.SetBool("estaSaltando", true);
        rigidbody2d.AddForce(Vector2.up * fuerzaSalto);

        /*(new Vector2(0, fuerzaSalto));*/
    }

    public void Ataque(){
        animator.SetBool("estaAtacando", true);

    }

    private void FixedUpdate(){
        rigidbody2d.velocity = new Vector2(Horizontal * velocidad, rigidbody2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Suelo")
        {
            saltosHechos = 0;
            animator.SetBool("estaSaltando", false);
        }
        /*else if (collision.gameObject.tag == "Finish")
        {
            
            //SceneManager.LoadScene("Menu");
        }*/
    }

}
