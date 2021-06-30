using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorPos : MonoBehaviour
{
    private float checkpointX, checkpointY;

    void Start()
    {
        if(PlayerPrefs.GetFloat("checkpointX") != 0){
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkpointX"),PlayerPrefs.GetFloat("checkpointY")));
        }
    }

    public void ReachCheckpoint(float x, float y){
        PlayerPrefs.SetFloat("checkpointX", x);
        PlayerPrefs.SetFloat("checkpointY", y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }        
    }
}
