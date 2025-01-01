using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscCollectMenu : MonoBehaviour
{
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider obj)
    {
        if (ServeSystem.checkServeDisc1)
        {
            Debug.Log("EnterServeDisc1");
            Debug.Log("isGreen1"+ RandomMenu.isGreencurry);
            Debug.Log("isGreen1Pass"+RandomMenu.isGreencurryPassServe);
            Debug.Log("isPad1" + RandomMenu.isPadthai);
            Debug.Log("isPad1Pass" + RandomMenu.isPadthaiPassServe);

            if (RandomMenu.isGreencurry && !RandomMenu.isGreencurryPassServe && obj.gameObject.tag == "GreencurryFinish" && !check) //Green
            {
                Debug.Log("DiscCollectMenuGreen1");
                //ServeSystem.checkServeDisc1 = true;
                CountdownTimer.checkIsSit1 = false;
                check = true;
                RandomMenu.isGreencurry = false;
            }
            else if (RandomMenu.isPadthai && !RandomMenu.isPadthaiPassServe && obj.gameObject.tag == "PadthaiFinish" && !check) //Padthai
            {
                Debug.Log("DiscCollectMenuPadthai1");
                //ServeSystem.checkServeDisc1 = true;
                CountdownTimer.checkIsSit1 = false;
                check = true;
                RandomMenu.isPadthai = false;
            }
            else if (RandomMenu.isSomtam && !RandomMenu.isSomtamPassServe && obj.gameObject.tag == "SomtamFinish" && !check) //Somtum
            {
                Debug.Log("DiscCollectMenuSomtum1");
                //ServeSystem.checkServeDisc1 = true;
                CountdownTimer.checkIsSit1 = false;
                check = true;
                RandomMenu.isSomtam = false;
            }
            else if (RandomMenu.isTomYumGoong && !RandomMenu.isTomYumGoongPassServe && obj.gameObject.tag == "TomyumgoongFinish" && !check) //Tomyum
            {
                Debug.Log("DiscCollectMenuTomYum1");
                //ServeSystem.checkServeDisc1 = true;
                CountdownTimer.checkIsSit1 = false;
                check = true;
                RandomMenu.isTomYumGoong = false;
            }
        }              
    }

    // Update is called once per frame
    void Update()
    {

    }
}
