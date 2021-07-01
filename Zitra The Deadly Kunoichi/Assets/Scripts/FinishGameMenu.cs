using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void QuitGame()
    {
       Debug.Log("QUIT!");
       Application.Quit();
    }

}
