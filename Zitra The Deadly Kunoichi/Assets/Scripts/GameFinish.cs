using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
   public GameManager gameManager;

   void OnTriggerEnter2D(){

       gameManager.CompleteGame();
       
   }
}