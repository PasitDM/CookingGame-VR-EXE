using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDiscCollect : MonoBehaviour
{
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider obj)
    {    
        if (ServeSystem.checkServeDisc2)
        {
            Debug.Log("EnterServeDisc2");
            Debug.Log("isGreen2" + TwoRandomMenu.isGreencurry);
            Debug.Log("isGreen2Pass" + TwoRandomMenu.isGreencurryPassServe);
            Debug.Log("isPad2" + TwoRandomMenu.isPadthai);
            Debug.Log("isPad2Pass" + TwoRandomMenu.isPadthaiPassServe);

            if (TwoRandomMenu.isGreencurry && !TwoRandomMenu.isGreencurryPassServe && obj.gameObject.tag == "GreencurryFinish" && !check) //Green
            {
                Debug.Log("DiscCollectMenuGreen2");
                //ServeSystem.checkServeDisc1 = true;
                CountTimeTwo.checkIsSit2 = false;
                check = true;
                TwoRandomMenu.isGreencurry = false;
            }
            else if (TwoRandomMenu.isPadthai && !TwoRandomMenu.isPadthaiPassServe && obj.gameObject.tag == "PadthaiFinish" && !check) //Padthai
            {
                Debug.Log("DiscCollectMenuPadthai1");
                //ServeSystem.checkServeDisc1 = true;
                CountTimeTwo.checkIsSit2 = false;
                check = true;
                TwoRandomMenu.isPadthai = false;
            }
            else if (TwoRandomMenu.isSomtam && !TwoRandomMenu.isSomtamPassServe && obj.gameObject.tag == "SomtamFinish" && !check) //Somtum
            {
                Debug.Log("DiscCollectMenuSomtum1");
                //ServeSystem.checkServeDisc1 = true;
                CountTimeTwo.checkIsSit2 = false;
                check = true;
                TwoRandomMenu.isSomtam = false;
            }
            else if (TwoRandomMenu.isTomYumGoong && !TwoRandomMenu.isTomYumGoongPassServe && obj.gameObject.tag == "TomyumgoongFinish" && !check) //Tomyum
            {
                Debug.Log("DiscCollectMenuTomYum1");
                //ServeSystem.checkServeDisc1 = true;
                CountTimeTwo.checkIsSit2 = false;
                check = true;
                TwoRandomMenu.isTomYumGoong = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
