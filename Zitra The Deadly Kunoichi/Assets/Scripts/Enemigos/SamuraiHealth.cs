using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiHealth : MonoBehaviour
{
	public bool esHerido;
	public GameObject efectoMuerte;
    SamuraiScript samurai;
	SpriteRenderer sprite;
	Blink material;
	Rigidbody2D rb;

	private void Start(){
		sprite = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		material = GetComponent<Blink>();
		samurai = GetComponent<SamuraiScript>();
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
				//Instantiate(efectoMuerte, transform.position, Quaternion.identity);
                Destroy(gameObject);
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
