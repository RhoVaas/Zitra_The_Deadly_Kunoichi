using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    public float velocidad;
    private bool Grounded;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private float Horizontal;
    int saltosHechos;
    int limiteSaltos = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        saltosHechos = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(saltosHechos < limiteSaltos){
            Salto();
            saltosHechos++;
            }

        }

    }


    private void Salto(){
        animator.SetBool("estaSaltando", true);
        rigidbody2d.AddForce(Vector2.up * fuerzaSalto);

        /*(new Vector2(0, fuerzaSalto));*/
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
    }

}
