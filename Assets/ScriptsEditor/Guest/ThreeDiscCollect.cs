using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDiscCollect : MonoBehaviour
{
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider obj)
    {
        if (ServeSystem.checkServeDisc3)
        {
            Debug.Log("EnterServeDisc3");
            Debug.Log("isGreen3" + ThreeRandomMenu.isGreencurry);
            Debug.Log("isGreen3Pass" + ThreeRandomMenu.isGreencurryPassServe);
            Debug.Log("isPad3" + ThreeRandomMenu.isPadthai);
            Debug.Log("isPad3Pass" + ThreeRandomMenu.isPadthaiPassServe);

            if (ThreeRandomMenu.isGreencurry && !ThreeRandomMenu.isGreencurryPassServe && obj.gameObject.tag == "GreencurryFinish" && !check) //Green
            {
                Debug.Log("DiscCollectMenuGreen1");
                //ServeSystem.checkServeDisc3 = true;
                CountTimeThree.checkIsSit3 = false;
                check = true;
                ThreeRandomMenu.isGreencurry = false;
            }
            else if (ThreeRandomMenu.isPadthai && !ThreeRandomMenu.isPadthaiPassServe && obj.gameObject.tag == "PadthaiFinish" && !check) //Padthai
            {
                Debug.Log("DiscCollectMenuPadthai1");
                //ServeSystem.checkServeDisc3 = true;
                CountTimeThree.checkIsSit3 = false;
                check = true;
                ThreeRandomMenu.isPadthai = false;
            }
            else if (ThreeRandomMenu.isSomtam && !ThreeRandomMenu.isSomtamPassServe && obj.gameObject.tag == "SomtamFinish" && !check) //Somtum
            {
                Debug.Log("DiscCollectMenuSomtum1");
                //ServeSystem.checkServeDisc3 = true;
                CountTimeThree.checkIsSit3 = false;
                check = true;
                ThreeRandomMenu.isSomtam = false;
            }
            else if (ThreeRandomMenu.isTomYumGoong && !ThreeRandomMenu.isTomYumGoongPassServe && obj.gameObject.tag == "TomyumgoongFinish" && !check) //Tomyum
            {
                Debug.Log("DiscCollectMenuTomYum1");
                //ServeSystem.checkServeDisc3 = true;
                CountTimeThree.checkIsSit3 = false;
                check = true;
                ThreeRandomMenu.isTomYumGoong = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
