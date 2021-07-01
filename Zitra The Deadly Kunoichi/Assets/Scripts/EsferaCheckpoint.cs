using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaCheckpoint : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){
           //anim.SetBool("esAlcanzado",true);
           Esperar();
           Destroy(gameObject);
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1);
    }
}
