using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    public Rigidbody rb;
    int i,x;
    public Animator anim;
    public float velocity;
    bool yuruyor;
    int beklesinmi;
    Player bz;
    public Transform ogrenci;
    public GameObject kirmizi;
    void Start()
    {
        bz = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        i = 2;
        yuruyor = true;
    }
    private void Update()
    {
        if (bz.tts.activeSelf)
        {
            anim.SetInteger("hareket", 1);
        }
        if (bz.ybesebasildi)
        {
            anim.SetInteger("hareket", 0);
            bz.ybesebasildi = false;
        }
        if (bz.yakalandi)
        {
            i = 0;
           transform.LookAt(ogrenci);
            anim.SetInteger("hareket", 2);
        }
        if (bz.kazan || bz.kaybet)
        {
            i = 0;
            kirmizi.SetActive(false);
            transform.LookAt(ogrenci);
            anim.SetInteger("hareket", 1);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (yuruyor && !bz.tts.activeSelf)
        {
            if (i == 1) // y
            {
                rb.velocity = new Vector3(0, 0, velocity);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 4);
            }
            if (i == 2) // a
            {
                rb.velocity = new Vector3(0, 0, -velocity);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,180,0) , 4);
            }
            if (i == 3) // sa
            {
                rb.velocity = new Vector3(velocity, 0, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0), 4);
            }
            if (i == 4) // so
            {
                rb.velocity = new Vector3(-velocity, 0, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -90, 0), 4);
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "asaso")
        {
            beklesinmi = Random.Range(1, 3);
           
              x = Random.Range(1, 5);
               if (x == 1)
               {
                   x = 2;
               }

            StartCoroutine(CoroutineTest());
           
        }
        if (other.tag == "ysaso")
        {
            beklesinmi = Random.Range(1, 3);

            x = Random.Range(1, 5);
            if (x == 2)
            {
                x = 1;
            }

            StartCoroutine(CoroutineTest());

        }
        if (other.tag == "yasaso")
        {
            beklesinmi = Random.Range(1, 3);

            x = Random.Range(1, 5);
           

            StartCoroutine(CoroutineTest());

        }
        if (other.tag == "yasa")
        {
            beklesinmi = Random.Range(1, 3);

            x = Random.Range(1, 5);
            if (x == 4)
            {
                x = 3;
            }

            StartCoroutine(CoroutineTest());

        }
        if (other.tag == "yaso")
        {
            beklesinmi = Random.Range(1, 3);

            x = Random.Range(1, 5);
            if (x == 3)
            {
                x = 4;
            }

            StartCoroutine(CoroutineTest());

        }
        if (other.tag == "yso")
        {
            beklesinmi = Random.Range(1, 3);

            x = Random.Range(1, 5);
            if (x == 2)
            {
                x = 4;
            }
            if (x == 3)
            {
                x = 1;
            }

            StartCoroutine(CoroutineTest());

        }
        if (other.tag == "ysa")
        {
            beklesinmi = Random.Range(1, 3);

            x = Random.Range(1, 5);
            if (x == 2)
            {
                x = 3;
            }
            if (x == 4)
            {
                x = 1;
            }

            StartCoroutine(CoroutineTest());

        }
        if (other.tag == "aso")
        {
            beklesinmi = Random.Range(1, 3);

            x = Random.Range(1, 5);
            if (x == 1)
            {
                x = 2;
            }
            if (x == 3)
            {
                x = 4;
            }

            StartCoroutine(CoroutineTest());

        }
        if (other.tag == "asa")
        {
            beklesinmi = Random.Range(1, 3);

            x = Random.Range(1, 5);
            if (x == 1)
            {
                x = 2;
            }
            if (x == 4)
            {
                x = 3;
            }

            StartCoroutine(CoroutineTest());

        }
    }
    IEnumerator CoroutineTest()
    {
        
        yield return new WaitForSeconds(velocity/3.33f);
        if (beklesinmi == 1)
        {
            yuruyor = false;
            anim.SetInteger("hareket", 1);
            StartCoroutine(karar());
        }
        if (beklesinmi == 2)
        {
            i = x;
        }
       

    }
    IEnumerator karar()
    {

        yield return new WaitForSeconds(2);
        yuruyor = true;
        anim.SetInteger("hareket", 0);
        i = x;

    }
}
