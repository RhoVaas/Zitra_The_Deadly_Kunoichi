using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiHealth : MonoBehaviour
{
	public bool esHerido;
	//public GameObject efectoMuerte;
    SamuraiScript samurai;
	SpriteRenderer sprite;
	Blink material;
	Rigidbody2D rb;
	Animator animator;

	private void Start(){
		sprite = this.GetComponent<SpriteRenderer>();
		rb = this.GetComponent<Rigidbody2D>();
		material = this.GetComponent<Blink>();
		samurai = this.GetComponent<SamuraiScript>();
		animator = this.GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag("Arma") && !esHerido)
		{
			samurai.healthPoints -= 1f;
			if (collision.transform.position.x < transform.position.x)
			{
				rb.AddForce(new Vector2 (samurai.knockbackForceX, samurai.knockbackForceY), ForceMode2D.Force);
			}
			else
			{
				rb.AddForce(-new Vector2 (-samurai.knockbackForceX, samurai.knockbackForceY), ForceMode2D.Force);
			}
			StartCoroutine(Damager());

            if (samurai.healthPoints <= 0){
				animator.SetBool("samuraiMuerte", true);
				//Instantiate(efectoMuerte, transform.position, Quaternion.identity);
                //Destroy(gameObject);
            }
		}
	}

	IEnumerator Damager(){
        esHerido = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        esHerido = false;
		sprite.material = material.original;
    }
}
