using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Zitra;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = Zitra.transform.position.x;
        transform.position = position;
        position.y = Zitra.transform.position.y;
        transform.position = position;

    }
}
