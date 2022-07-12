using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody rb;
    bool Up;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Up)
        {
            rb.velocity = new Vector3(0, 0.4f, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, -0.4f, 0);
        }
        transform.Rotate(0, 4, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ust")
        {
            Up = false;
        }
        if (other.tag == "alt")
        {
            Up = true;
        }
    }
}
