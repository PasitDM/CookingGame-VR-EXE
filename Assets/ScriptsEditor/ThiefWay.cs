using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefWay : MonoBehaviour
{
    public GameObject[] waypoint;
    int current = 0;
    float rotSpeet;
    public float speed;
    float WPradius = 1;
    int stop = 0;
    public int loops = 0;
    private Transform player;

    private Animator anim;

    float currentTime = 0;
    float startingTime = 5;
    public bool startWalk = false;

    private float timer = 0;
    private float timerMax = 0;
    public int detectP = 0;

    Rigidbody m_Rigidbody;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        currentTime = startingTime;
        anim = GetComponent<Animator>();


        if (gameObject.name == "nGardenGuest1")
        {
            currentTime = 1;
        }
        else if (gameObject.name == "Thief1")
        {
            currentTime = 3;
        }

        //counter1 = GameObject.Find("serveDisc").GetComponent<Transform>();
    }

    private bool Waited(float seconds)
    {
        timerMax = seconds;

        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            return true; //max reached - waited x - seconds
        }

        return false;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0) // Start Walking
        {
            if (stop == 0)
            {
                // transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, waypoint[current].transform.position, Time.deltaTime * speed);
                //transform.position = Vector3.Rotate(0, 180, 0);
            }
            else
            {
                //transform.LookAt(player);
                //transform.position = Vector3.MoveTowards(transform.position, player.position, 1 * Time.deltaTime);
            }

            if (stop == 0 && Vector3.Distance(waypoint[current].transform.position, transform.position) < WPradius)
            {
                if (current >= 0)
                {
                    //ถึงแต่ละมาคไม่เอาจุดเริ่ม
                    anim.SetBool("isWalking", false);
                    // if (!Waited(1)) return; //รอ2วิ
                    timer = 0; //reset delay
                    //Debug.Log(current);
                    if (current <= waypoint.Length)
                    {

                        if (current < waypoint.Length - 1)
                        {

                            transform.LookAt(waypoint[current + 1].transform.position);
                        }

                        if (current == waypoint.Length - 1)
                        {

                            //transform.LookAt(waypoint[waypoint.Length-1].transform.position);
                        }
                    }
                }
                //ถึงจุดมาค 
                current++;
                anim.SetBool("isWalking", true);

                if (current >= waypoint.Length)
                {
                    //ถึงจุดหมาย
                    anim.SetBool("isWalking", false);
                    if (loops == 0)
                    {
                        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                        //สุดทาง
                        stop = 1;
                        //anim.SetBool("isAim", true);
                        //transform.LookAt(player);
                    }
                    current = 0;
                }
            }
        }
    }
}
