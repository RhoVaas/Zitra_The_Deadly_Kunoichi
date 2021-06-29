using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void AlMenuPrincipal(){
        SceneManager.LoadScene("Menu");
    }
}
