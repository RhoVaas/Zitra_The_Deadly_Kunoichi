using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiHealth : MonoBehaviour
{
    SamuraiScript samurai;

	private void Start(){
		samurai = GetComponent<SamuraiScript>();
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag("Arma")){
			samurai.healthPoints -= 2f;

            if (samurai.healthPoints <= 0){
                Destroy(gameObject);
            }
		}
	}
}
