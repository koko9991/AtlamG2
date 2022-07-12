using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tts : MonoBehaviour
{
   
    bool GetBigger;
    private void Start()
    {
        GetBigger = true;
    }
    void FixedUpdate()
    {
        if (transform.localScale.x >= 1.15f)
        {
            GetBigger = false;
        }
        if (transform.localScale.x <= 0.8f)
        {
            GetBigger = true;
        }

        if (GetBigger)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, 1);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, 1);
        }
        
    }
}
