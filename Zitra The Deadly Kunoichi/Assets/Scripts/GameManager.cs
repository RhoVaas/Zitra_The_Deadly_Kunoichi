using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject col;
    public Renderer fondo;
    // Start is called before the first frame update
    void Start()
    {
        //Creacion de mapa
        /*for (int i = 0; i < 21; i++)
        {
            Instantiate(col, new Vector2(-10 + i, -3), Quaternion.identity);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f,0) * Time.deltaTime; 
    }
}
