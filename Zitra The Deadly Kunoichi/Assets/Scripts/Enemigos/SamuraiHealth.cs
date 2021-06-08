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

	private void Start(){
		sprite = GetComponent<SpriteRenderer>();
		material = GetComponent<Blink>();
		samurai = GetComponent<SamuraiScript>();
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag("Arma") && !esHerido)
		{
			samurai.healthPoints -= 2f;
			StartCoroutine(Damager());

            if (samurai.healthPoints <= 0){
				Instantiate(efectoMuerte, transform.position, Quaternion.identity);
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
