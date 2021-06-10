using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Atrás()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
   {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
