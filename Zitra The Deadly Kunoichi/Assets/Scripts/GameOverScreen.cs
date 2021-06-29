using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    JugadorHealth zitra;
    
    public void Setup(){
        gameObject.SetActive(true);
    }


    public void RestartButton(){
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton(){
        SceneManager.LoadScene("Menu");
    }
}