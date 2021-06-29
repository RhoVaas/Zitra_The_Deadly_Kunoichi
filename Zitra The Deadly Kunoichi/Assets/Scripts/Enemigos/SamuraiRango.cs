using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiRango : MonoBehaviour
{
    public Animator animator;
    public SamuraiScript samurai;

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){
            samurai.Atacar();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
