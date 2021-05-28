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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }else
        {
            Grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)  && Grounded)
        {
            Salto();
        }

    }

    private void Salto(){
        animator.SetBool("estaSaltando", true);
        rigidbody2d.AddForce/*(new Vector2(0, fuerzaSalto));*/(Vector2.up * fuerzaSalto);
    }

    private void FixedUpdate(){
        rigidbody2d.velocity = new Vector2(Horizontal * velocidad, rigidbody2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);
        }
    }

}
