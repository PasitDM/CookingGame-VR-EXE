using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayOfGuest : MonoBehaviour
{
    public GameObject[] waypoint;
    int current = 0;
    float rotSpeet;
    public float speed;
    float WPradius = 1;
    int stop = 0;

    float currentTime = 0;
    float startingTime = 5;
    public bool startWalk = false;

    private Transform player;
    private Transform counter1;
    private Animator mAnimator;

    public bool walkFinish;

    Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        currentTime = startingTime;
        mAnimator = GetComponent<Animator>();

        if (gameObject.name == "Guest1fatmanLaughing Variant")
        {
            currentTime = 5;
        }
        else if (gameObject.name == "Guest2fatmanUI Variant")
        {
            currentTime = 4;
        }
        else if (gameObject.name == "Guest3UIwomanLaugh")
        {
            currentTime = 6;
        }
        else if (gameObject.name == "MaleFreeGuest1")
        {
            currentTime = 2;
        }
        else if (gameObject.name == "nGardenGuest1")
        {
            currentTime = 2;
        }

        //player = GameObject.Find("FPSController").GetComponent<Transform>();
        //counter1 = GameObject.Find("serveDisc").GetComponent<Transform>();
    }

    void Update()
    {
        bool walking = false;
        bool standing = false; 

        
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0) // Start Walking
        {
            if (stop == 0 && Vector3.Distance(waypoint[current].transform.position, transform.position) < WPradius)
            {
                
                
                walking = true;
                
                mAnimator.SetBool("walking", walking);
                current++;
                

                if (current >= waypoint.Length)
                {
                    Debug.Log("Standing");
                    stop = 1;
                    walking = false;
                    mAnimator.SetBool("walking", walking);
                    walkFinish = true;
                    //transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
                    transform.Rotate(0,90,0);
                    //transform.LookAt(player);
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                   
                }
            }
            if (stop == 0)
            {
                
                standing = true;
                transform.LookAt(player);
                //mAnimator.SetBool("walking", walking);
                transform.position = Vector3.MoveTowards(transform.position, waypoint[current].transform.position, Time.deltaTime * speed);
            }
            else
            {
               
                //transform.LookAt(player);
                //transform.position = Vector3.MoveTowards(transform.position, player.position, 1 * Time.deltaTime);
            }
        }
       

        
    }
}