using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject col;
    
    private static GameManager instance;

    public void CompleteLevel(){
        Debug.Log("Nivel terminado!");
        SceneManager.LoadScene("Nivel2");
    }

    public void CompleteGame(){
        Debug.Log("Juego terminado!");
        SceneManager.LoadScene("JuegoCompletado");
    }

    public void GameOver(){
        Debug.Log("Nivel terminado!");
    }

}
