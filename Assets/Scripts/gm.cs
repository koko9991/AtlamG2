using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour
{
   public int q1, q2;
    public GameObject a1, b1, c1, d1, a2, b2, c2, d2;
    Player bz;
    void Start()
    {
        bz = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (bz.sorusayisi == 2)
        {
            q1 = Random.Range(1, 5);
            q2 = Random.Range(1, 5);
            if (q1 == 1)
            {
                a1.SetActive(true);
                b1.SetActive(false);
                c1.SetActive(false);
                d1.SetActive(false);
            }
            if (q1 == 2)
            {
                a1.SetActive(false);
                b1.SetActive(true);
                c1.SetActive(false);
                d1.SetActive(false);
            }
            if (q1 == 3)
            {
                a1.SetActive(false);
                b1.SetActive(false);
                c1.SetActive(true);
                d1.SetActive(false);
            }
            if (q1 == 4)
            {
                a1.SetActive(false);
                b1.SetActive(false);
                c1.SetActive(false);
                d1.SetActive(true);
            }
            if (q2 == 1)
            {
                a2.SetActive(true);
                b2.SetActive(false);
                c2.SetActive(false);
                d2.SetActive(false);
            }
            if (q2 == 2)
            {
                a2.SetActive(false);
                b2.SetActive(true);
                c2.SetActive(false);
                d2.SetActive(false);
            }
            if (q2 == 3)
            {
                a2.SetActive(false);
                b2.SetActive(false);
                c2.SetActive(true);
                d2.SetActive(false);
            }
            if (q2 == 4)
            {
                a2.SetActive(false);
                b2.SetActive(false);
                c2.SetActive(false);
                d2.SetActive(true);
            }
        }
       
    }

    
}
