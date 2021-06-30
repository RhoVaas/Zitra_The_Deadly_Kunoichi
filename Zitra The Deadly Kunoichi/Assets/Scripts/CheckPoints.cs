using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    void Start(){
        
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){
           coll.GetComponent<JugadorPos>().ReachCheckpoint(transform.position.x, transform.position.y);
        }
    }
}
