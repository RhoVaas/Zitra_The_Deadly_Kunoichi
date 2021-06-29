using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorHealth : MonoBehaviour
{
    public float salud;
    public float maximoSalud;
    bool esInmune;
    public float inmunityTime;
    Blink material;
    SpriteRenderer sprite;
    public float knockbackForceX;
	public float knockbackForceY;
    Rigidbody2D rb;
    public GameManager gameManager;
    //private Animator animator;
    

    
    void Start()
    {
        //animator = this.GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
        salud = maximoSalud;
    }

    
    void Update()
    {
        if(salud > maximoSalud){
            salud = maximoSalud;
        }

        else if(salud < 1){
            //Si zitra muere, te manda a la pantalla de game over
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Enemigo") && !esInmune)
        {
            salud -= collision.GetComponent<SamuraiScript>().dañoHecho;

            if (collision.transform.position.x > transform.position.x)
			{
				rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);


			}
			else
			{
				rb.AddForce(new Vector2 (knockbackForceX, knockbackForceY), ForceMode2D.Force);
                
			}

            StartCoroutine(Inmunidad());
            if (salud <= 0)
            {
                //game over
                print("Player dead");
            }
        }

        if(collision.gameObject.tag == "Spikes"){
            salud -= 5;
            if (collision.transform.position.x > transform.position.x)
			{
				rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
			}
			else
			{
				rb.AddForce(new Vector2 (knockbackForceX, knockbackForceY), ForceMode2D.Force);   
			}
            StartCoroutine(Inmunidad());
        }

        if(collision.CompareTag("Respawn")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator Inmunidad(){
        esInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        esInmune = false;
    }
}
