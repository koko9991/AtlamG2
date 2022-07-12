using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public FixedJoystick js;
    protected float cameraAngleY;
    public GameObject joy;
    public GameObject render;
    public Rigidbody rb;
    public float movespeed;
    public Animator anim;
    public GameObject cam1, cam2;
    public GameObject lookbutton,backbuton,oturbuton,upbuton,paperbuton,back2buton,finishbutton,resbuton,nextlevelbuton;
    public bool look;
    public Transform target,target2;
    public GameObject bizimsandalye,bizimmasa;
    gm gamemanager;
    public GameObject bizimkagit;
    bool oturuluyor;
    public GameObject a1, b1, c1, d1, a2, b2, c2, d2,a3,b3,c3,d3,a4,b4,c4,d4;
    public bool yakalandi;
    public int sorusayisi;
    public bool kazan,kaybet;
    bool birdogru, ikidogru,ucdogru,dortdogru;
    public Image timebar;
    public float maxtimescene;
     float timescene;
    public GameObject tts;
    public bool ybesebasildi;
    private void Start()
    {
        timescene = maxtimescene;
        lookbutton.SetActive(false);
        backbuton.SetActive(false);
        back2buton.SetActive(false);
        oturbuton.SetActive(false);
        bizimkagit.SetActive(false);
        upbuton.SetActive(false);
        paperbuton.SetActive(false);
        finishbutton.SetActive(false);
        resbuton.SetActive(false);
        oturuluyor = true;
        joy.SetActive(false);
        if (sorusayisi == 2)
        {
            a1.SetActive(false);
            b1.SetActive(false);
            c1.SetActive(false);
            d1.SetActive(false);
            a2.SetActive(false);
            b2.SetActive(false);
            c2.SetActive(false);
            d2.SetActive(false);
        }
        if (sorusayisi == 3)
        {
            a1.SetActive(false);
            b1.SetActive(false);
            c1.SetActive(false);
            d1.SetActive(false);
            a2.SetActive(false);
            b2.SetActive(false);
            c2.SetActive(false);
            d2.SetActive(false);
            a3.SetActive(false);
            b3.SetActive(false);
            c3.SetActive(false);
            d3.SetActive(false);
        }
        if (sorusayisi == 4)
        {
            a1.SetActive(false);
            b1.SetActive(false);
            c1.SetActive(false);
            d1.SetActive(false);
            a2.SetActive(false);
            b2.SetActive(false);
            c2.SetActive(false);
            d2.SetActive(false);
            a3.SetActive(false);
            b3.SetActive(false);
            c3.SetActive(false);
            d3.SetActive(false);
            a4.SetActive(false);
            b4.SetActive(false);
            c4.SetActive(false);
            d4.SetActive(false);
        }
        gamemanager = GameObject.FindGameObjectWithTag("gm").GetComponent<gm>();
    }
   
    private void Update()
    {

        
        rb.velocity = new Vector3(js.Horizontal * movespeed, rb.velocity.y, js.Vertical * movespeed);
        if ((js.Horizontal != 0 || js.Vertical != 0) && !yakalandi && !kazan && !kaybet)
        {
               transform.rotation = Quaternion.LookRotation(rb.velocity);


        }
        if (!kazan && !kaybet && !yakalandi && !tts.activeSelf)
        {
            timescene -= Time.deltaTime;
            timebar.fillAmount = timescene / maxtimescene;
        }
      
        if (timescene <= 0)
        {
            kaybet = true;
            anim.SetInteger("hareket", 5);
            bizimkagit.SetActive(false);
            lookbutton.SetActive(false);
            backbuton.SetActive(false);
            back2buton.SetActive(false);
            oturbuton.SetActive(false);
            bizimkagit.SetActive(false);
            upbuton.SetActive(false);
            paperbuton.SetActive(false);
            finishbutton.SetActive(false);
            joy.SetActive(false);
            resbuton.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }

        if (js.Horizontal == 0 && js.Vertical == 0 && !oturuluyor && !yakalandi && !kazan && !kaybet)
        {
            anim.SetInteger("hareket", 0);
        }
        if (rb.velocity.magnitude > 0.1f && rb.velocity.magnitude < 2.2f && !yakalandi && !kazan && !kaybet)
        {
            anim.SetInteger("hareket", 2);
        }
        if (rb.velocity.magnitude > 2.2f && !yakalandi && !kazan && !kaybet)
        {
            anim.SetInteger("hareket", 1);
        }
        if (oturuluyor && !kazan && !kaybet)
        {
            anim.SetInteger("hareket", 4);
        }


    }
    
    private void FixedUpdate()
    {
          




        if (cam2.activeSelf && look)
        {
            if(Vector3.Distance(target.position,transform.position)< Vector3.Distance(target2.position, transform.position))
            {
                cam2.transform.LookAt(target);
            }
            if (Vector3.Distance(target.position, transform.position) > Vector3.Distance(target2.position, transform.position))
            {
                cam2.transform.LookAt(target2);
            }
        }
       
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "masa" && !look && !yakalandi)
        {
            lookbutton.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "masa")
        {
            lookbutton.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "hocaview" && !oturuluyor)
        {
            yakalandi = true;
            resbuton.SetActive(true);
            joy.SetActive(false);
            anim.SetInteger("hareket", 5);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            cam1.SetActive(true);
            cam2.SetActive(false);
            lookbutton.SetActive(false);
            backbuton.SetActive(false);
            back2buton.SetActive(false);
            oturbuton.SetActive(false);
            bizimkagit.SetActive(false);
            upbuton.SetActive(false);
            paperbuton.SetActive(false);
            finishbutton.SetActive(false);
        }
        if (other.gameObject.tag == "otur"  && !oturuluyor && !yakalandi && !kazan && !kaybet)
        {
            oturbuton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "otur")
        {
            oturbuton.SetActive(false);
        }
    }
    public void gelenbuton(int butonNo)
    {
        if (butonNo == 1)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            lookbutton.SetActive(false);
            joy.SetActive(false);
            backbuton.SetActive(true);
            look = true;
        }
        if (butonNo == 2)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            lookbutton.SetActive(false);
            oturbuton.SetActive(false);
            joy.SetActive(true);
            backbuton.SetActive(false);
            look = false;
            
            bizimkagit.SetActive(false);
        }
        if (butonNo == 5)
        {
          //cam1.SetActive(false);
          //  cam2.SetActive(true);
            oturbuton.SetActive(false);
            joy.SetActive(false);
           
            paperbuton.SetActive(false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //cam2.transform.rotation= Quaternion.Euler(43.24f, 0, 0);
            bizimkagit.SetActive(true);
            back2buton.SetActive(true);
            finishbutton.SetActive(true);
            transform.position = new Vector3(bizimsandalye.transform.position.x, 0, bizimsandalye.transform.position.z + 0.65f);
        }
        if (butonNo == 3)
        {
            oturuluyor = true;
            oturbuton.SetActive(false);
            upbuton.SetActive(true);
            joy.SetActive(false);
            paperbuton.SetActive(true);

            transform.rotation = Quaternion.Euler(0, 0, 0);
            //cam2.transform.rotation= Quaternion.Euler(43.24f, 0, 0);
         //   bizimkagit.SetActive(true);
            transform.position = new Vector3(bizimsandalye.transform.position.x, 0, bizimsandalye.transform.position.z + 0.65f);
        }
        if (butonNo == 4)
        {
            oturuluyor = false;
            joy.SetActive(true);
            upbuton.SetActive(false);
            oturbuton.SetActive(true);
            paperbuton.SetActive(false);
        }
        if (butonNo == 6)
        {
            oturuluyor = true;
            paperbuton.SetActive(true);
            upbuton.SetActive(true);
            bizimkagit.SetActive(false);
            back2buton.SetActive(false);
            finishbutton.SetActive(false);

        }
        if (butonNo == 7)
        {
            a1.SetActive(true);
            b1.SetActive(false);
            c1.SetActive(false);
            d1.SetActive(false);

        }
        if (butonNo == 8)
        {
            a1.SetActive(false);
            b1.SetActive(true);
            c1.SetActive(false);
            d1.SetActive(false);

        }
        if (butonNo == 9)
        {
            a1.SetActive(false);
            b1.SetActive(false);
            c1.SetActive(true);
            d1.SetActive(false);

        }
        if (butonNo == 10)
        {
            a1.SetActive(false);
            b1.SetActive(false);
            c1.SetActive(false);
            d1.SetActive(true);

        }
        if (butonNo == 11)
        {
            a2.SetActive(true);
            b2.SetActive(false);
            c2.SetActive(false);
            d2.SetActive(false);

        }
        if (butonNo == 12)
        {
            a2.SetActive(false);
            b2.SetActive(true);
            c2.SetActive(false);
            d2.SetActive(false);

        }
        if (butonNo == 13)
        {
            a2.SetActive(false);
            b2.SetActive(false);
            c2.SetActive(true);
            d2.SetActive(false);

        }
        if (butonNo == 14)
        {
            a2.SetActive(false);
            b2.SetActive(false);
            c2.SetActive(false);
            d2.SetActive(true);

        }
        if (butonNo == 15)
        {
            a3.SetActive(true);
            b3.SetActive(false);
            c3.SetActive(false);
            d3.SetActive(false);

        }
        if (butonNo == 16)
        {
            a3.SetActive(false);
            b3.SetActive(true);
            c3.SetActive(false);
            d3.SetActive(false);

        }
        if (butonNo == 17)
        {
            a3.SetActive(false);
            b3.SetActive(false);
            c3.SetActive(true);
            d3.SetActive(false);

        }
        if (butonNo == 18)
        {
            a3.SetActive(false);
            b3.SetActive(false);
            c3.SetActive(false);
            d3.SetActive(true);

        }
        if (butonNo == 19)
        {
            a4.SetActive(true);
            b4.SetActive(false);
            c4.SetActive(false);
            d4.SetActive(false);

        }
        if (butonNo == 20)
        {
            a4.SetActive(false);
            b4.SetActive(true);
            c4.SetActive(false);
            d4.SetActive(false);

        }
        if (butonNo == 21)
        {
            a4.SetActive(false);
            b4.SetActive(false);
            c4.SetActive(true);
            d4.SetActive(false);

        }
        if (butonNo == 22)
        {
            a4.SetActive(false);
            b4.SetActive(false);
            c4.SetActive(false);
            d4.SetActive(true);

        }
        if (butonNo == 24)
        {
            Application.LoadLevel(Application.loadedLevel);

        }
        if (butonNo == 25)
        {
            tts.SetActive(false);
            upbuton.SetActive(true);
            paperbuton.SetActive(true);
            ybesebasildi = true;
        }
        if (butonNo == 26)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Application.LoadLevel(1);
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Application.LoadLevel(2);
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Application.LoadLevel(3);
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                Application.LoadLevel(0);
            }

        }




        if (butonNo == 23)
        {
            if (sorusayisi == 2)
            {
                if((gamemanager.q1==1 && a1.activeSelf))
                {
                    birdogru = true;
                }
                if ((gamemanager.q1 == 2 && b1.activeSelf))
                {
                    birdogru = true;
                }
                if ((gamemanager.q1 == 3 && c1.activeSelf))
                {
                    birdogru = true;
                }
                if ((gamemanager.q1 == 4 && d1.activeSelf))
                {
                    birdogru = true;
                }
                if ((gamemanager.q2 == 1 && a2.activeSelf))
                {
                    ikidogru = true;
                }
                if ((gamemanager.q2 == 2 && b2.activeSelf))
                {
                    ikidogru = true;
                }
                if ((gamemanager.q2 == 3 && c2.activeSelf))
                {
                    ikidogru = true;
                }
                if ((gamemanager.q2 == 4 && d2.activeSelf))
                {
                    ikidogru = true;
                }
                if(birdogru && ikidogru)
                {
                    kazan = true;
                    transform.position = new Vector3(bizimmasa.transform.position.x, bizimmasa.transform.position.y + 1, bizimmasa.transform.position.z);
                    anim.SetInteger("hareket", 6);
                    bizimkagit.SetActive(false);
                    lookbutton.SetActive(false);
                    backbuton.SetActive(false);
                    back2buton.SetActive(false);
                    oturbuton.SetActive(false);
                    bizimkagit.SetActive(false);
                    upbuton.SetActive(false);
                    paperbuton.SetActive(false);
                    finishbutton.SetActive(false);
                    nextlevelbuton.SetActive(true);
                }
                else
                {
                    kaybet = true;
                    anim.SetInteger("hareket", 5);
                    bizimkagit.SetActive(false);
                    lookbutton.SetActive(false);
                    backbuton.SetActive(false);
                    back2buton.SetActive(false);
                    oturbuton.SetActive(false);
                    bizimkagit.SetActive(false);
                    upbuton.SetActive(false);
                    paperbuton.SetActive(false);
                    finishbutton.SetActive(false);
                    resbuton.SetActive(true);
                }
            }
        }
    }
}
    