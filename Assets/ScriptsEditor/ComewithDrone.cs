using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComewithDrone : MonoBehaviour
{
    public GameObject[] waypoint;
    int current = 0;
    float rotSpeet;
    public float speed;
    float WPradius = 1;
    int stop = 0;
    public int loops = 0;
    private Transform player;
    //public Animator anim;
    private float timer = 0;
    private float timerMax = 0;
    public int detectP = 0;





    void Start()
    {
        player = GameObject.Find("a").GetComponent<Transform>();

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
        if (stop == 0 && detectP == 0)
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
                //anim.SetBool("isWalk", false);
                if (!Waited(1)) return; //รอ2วิ
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

                        transform.LookAt(waypoint[0].transform.position);
                    }
                }
            }
            //ถึงจุดมาค 
            current++;
            //anim.SetBool("isWalk", true);

            if (current >= waypoint.Length)
            {
                //ถึงจุดหมาย
                //anim.SetBool("isWalk", false);
                if (loops == 0)
                {
                    if (!Waited(2)) return;
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