using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralRango : MonoBehaviour
{
    public Animator animator;
    public GeneralSamuraiScript general;

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){
            general.Atacar();
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
