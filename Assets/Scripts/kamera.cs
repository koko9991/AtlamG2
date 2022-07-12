using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public GameObject karakter;
    public float indexy, indexz;
    void FixedUpdate()
    {
        transform.position = new Vector3(karakter.transform.position.x, karakter.transform.position.y+indexy, karakter.transform.position.z +indexz);
    }
}
