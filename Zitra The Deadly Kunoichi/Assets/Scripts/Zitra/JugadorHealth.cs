using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorHealth : MonoBehaviour
{
    public float salud;
    public float maximoSalud;
    bool esInmune;
    public float inmunityTime;
    //Blink material;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        //material = GetComponent<Blink>;
        salud = maximoSalud;
    }

    // Update is called once per frame
    void Update()
    {
        if(salud > maximoSalud){
            salud = maximoSalud;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Enemigo") && !esInmune)
        {
            salud -= collision.GetComponent<SamuraiScript>().dañoHecho;
            StartCoroutine(Inmunidad());
            if (salud <= 0)
            {
                //game over
                print("Player dead");
            }
        }
    }

    IEnumerator Inmunidad(){
        esInmune = true;
        //sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        //sprite.material = material.original;
        esInmune = false;
    }
}
