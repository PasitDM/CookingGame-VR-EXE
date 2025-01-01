using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMenuServe : MonoBehaviour
{
    public ParticleSystem partSystem;

    public bool check = false;

    public GameObject objToCreate;
    public Transform posToCreate;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider obj) // Object is Menu ex. VargreenCurryFull
    {
        //------------------------Guest 1----Guest 1----Guest 1----Guest 1----Guest 1------------------------------
        if (gameObject.tag == "GreencurryFinish" && obj.gameObject.tag == "Serve" && !check && RandomMenu.isGreencurry && RandomMenu.isGreencurryPassServe)
        {
            Debug.Log("DestroyGreen1inCollectMenuServe1");
            Destroy(gameObject);
            check = true;
            RandomMenu.isGreencurryPassServe = false;
        }
        else if (gameObject.tag == "PadthaiFinish" && obj.gameObject.tag == "Serve" && !check && RandomMenu.isPadthai && RandomMenu.isPadthaiPassServe)
        {
            Debug.Log("DestroyPad1inCollectMenuServe1");
            Destroy(gameObject);
            check = true;
            RandomMenu.isPadthaiPassServe = false;
        }

        else if (gameObject.tag == "SomtumFinish" && obj.gameObject.tag == "Serve" && !check && RandomMenu.isSomtam && RandomMenu.isSomtamPassServe)
        {
            Debug.Log("DestroySomtum1inCollectMenuServe1");
            check = true;
            Destroy(gameObject);
            RandomMenu.isSomtamPassServe = false;
        }
        else if (gameObject.tag == "TomyumgoongFinish" && obj.gameObject.tag == "Serve" && !check && RandomMenu.isTomYumGoong && RandomMenu.isTomYumGoongPassServe)
        {
            check = true;
            Destroy(gameObject); 
            RandomMenu.isTomYumGoongPassServe = false;
        }

        //------------------------Guest 2----Guest 2----Guest 2----Guest 2----Guest 2-------------------------------
        if (gameObject.tag == "GreencurryFinish" && obj.gameObject.tag == "Serve" && !check && TwoRandomMenu.isGreencurry && TwoRandomMenu.isGreencurryPassServe)
        {
            Debug.Log("DestroyGreen2inCollectMenuServe2");
            Destroy(gameObject);
            check = true;
            TwoRandomMenu.isGreencurryPassServe = false;
        }
        else if (gameObject.tag == "PadthaiFinish" && obj.gameObject.tag == "Serve" && !check && TwoRandomMenu.isPadthai && TwoRandomMenu.isPadthaiPassServe)
        {
            Debug.Log("DestroyPad2inCollectMenuServe2");
            Destroy(gameObject);
            check = true;
            TwoRandomMenu.isPadthaiPassServe = false;
        }
        else if (gameObject.tag == "SomtumFinish" && obj.gameObject.tag == "Serve" && !check && TwoRandomMenu.isSomtam && TwoRandomMenu.isSomtamPassServe)
        {
            Debug.Log("DestroySomtum2inCollectMenuServe2");
            check = true;
            Destroy(gameObject);
            TwoRandomMenu.isSomtamPassServe = false;
        }
        else if (gameObject.tag == "TomyumgoongFinish" && obj.gameObject.tag == "Serve" && !check && TwoRandomMenu.isTomYumGoong && TwoRandomMenu.isTomYumGoongPassServe)
        {
            check = true;
            Destroy(gameObject);
            TwoRandomMenu.isTomYumGoongPassServe = false;
        }

        //------------------------Guest 3----Guest 3----Guest 3----Guest 3----Guest 3-------------------------------
        if (gameObject.tag == "GreencurryFinish" && obj.gameObject.tag == "Serve" && !check && ThreeRandomMenu.isGreencurry && ThreeRandomMenu.isGreencurryPassServe)
        {
            Debug.Log("DestroyGreen3inCollectMenuServe3");
            check = true;
            Destroy(gameObject);
            ThreeRandomMenu.isGreencurryPassServe = false;
        }
        else if (gameObject.tag == "PadthaiFinish" && obj.gameObject.tag == "Serve" && !check && ThreeRandomMenu.isPadthai && ThreeRandomMenu.isPadthaiPassServe)
        {
            Debug.Log("DestroyPad3inCollectMenuServe3");
            Destroy(gameObject);
            check = true;
            ThreeRandomMenu.isPadthaiPassServe = false;
        }
        else if (gameObject.tag == "SomtumFinish" && obj.gameObject.tag == "Serve" && !check && ThreeRandomMenu.isSomtam && ThreeRandomMenu.isSomtamPassServe)
        {
            Debug.Log("DestroySomtum3inCollectMenuServe3");
            check = true;
            Destroy(gameObject);
            ThreeRandomMenu.isSomtamPassServe = false;
        }
        else if (gameObject.tag == "TomyumgoongFinish" && obj.gameObject.tag == "Serve" && !check && ThreeRandomMenu.isTomYumGoong && ThreeRandomMenu.isTomYumGoongPassServe)
        {
            check = true;
            Destroy(gameObject);
            ThreeRandomMenu.isTomYumGoongPassServe = false;
        }
    }
}
