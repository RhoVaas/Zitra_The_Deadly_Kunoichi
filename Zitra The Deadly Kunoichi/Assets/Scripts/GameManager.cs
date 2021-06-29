using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject col;
    public Renderer fondo;
    private static GameManager instance;
    public Vector2 lastCheckPointPos;

    //Intento de Checkpoint
    /*void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        }else{
            //Destroy(gameObject);
        }
    }*/

    void Start()
    {
        
    }

    
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f,0) * Time.deltaTime;
    }

    public void CompleteLevel(){
        Debug.Log("Nivel terminado!");
        SceneManager.LoadScene("Menu");
    }

    public void GameOver(){
        Debug.Log("Nivel terminado!");
    }

}
