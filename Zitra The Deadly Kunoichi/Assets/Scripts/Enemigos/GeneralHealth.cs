using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralHealth : MonoBehaviour
{
    public bool esHerido;
	public GameObject efectoMuerte;
    GeneralSamuraiScript general;
	SpriteRenderer sprite;
	Blink material;
	Rigidbody2D rb;

	private void Start(){
		sprite = this.GetComponent<SpriteRenderer>();
		rb = this.GetComponent<Rigidbody2D>();
		material = this.GetComponent<Blink>();
		general = this.GetComponent<GeneralSamuraiScript>();
	}

    private void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag("Arma") && !esHerido)
		{
			general.healthPoints -= 1f;
			if (collision.transform.position.x < transform.position.x)
			{
				rb.AddForce(new Vector2 (general.knockbackForceX, general.knockbackForceY), ForceMode2D.Force);
			}
			else
			{
				rb.AddForce(-new Vector2 (-general.knockbackForceX, general.knockbackForceY), ForceMode2D.Force);
			}
			StartCoroutine(Damager());

            if (general.healthPoints <= 0){
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
