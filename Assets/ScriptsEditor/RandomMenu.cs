using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomMenu : MonoBehaviour
{
    public int value;

    public static bool isGreencurry;
    public static bool isPadthai;
    public static bool isTomYumGoong;
    public static bool isSomtam;

    public static bool isGreencurryPassServe;
    public static bool isPadthaiPassServe;
    public static bool isTomYumGoongPassServe;
    public static bool isSomtamPassServe;

    public GameObject greenPhoto;
    public GameObject padthaiPhoto;
    public GameObject somtumPhoto;
    public GameObject tomyumPhoto;
    


    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        isGreencurry = false;
        isPadthai = false;
        isSomtam = false;
        isTomYumGoong = false;
        

        if (sceneName == "Level1(ThreeMenu)") // Check Scene Level1
        {
            value = Random.Range(1, 3);
        }
        else if (sceneName == "Level2")
        {
            value = Random.Range(1, 4);
        }


        if (value == 1)
        {
            isGreencurry = true;
            isGreencurryPassServe = true;
            setPicture("GreenCurryCan");
        }
        if (value == 2)
        {
            isPadthai = true;
            isPadthaiPassServe = true;
            setPicture("PadthaiCan");
        }
        if (value == 3)
        {
            isSomtam = true;
            isSomtamPassServe = true;
            setPicture("SomtumCan");         
        }
        if (value == 4)
        {
            isTomYumGoong = true;
            isTomYumGoongPassServe = true;
            setPicture("TomyumgoongCan"); 
        }
        
    }

    void setPicture(string pic)
    {
        foreach (Transform child in transform)
        {
            if (child.name == pic)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGreencurry && !isPadthai && !isTomYumGoong && !isSomtam && 
            !isGreencurryPassServe && !isPadthaiPassServe && !isTomYumGoongPassServe && !isSomtamPassServe)
        {           
            greenPhoto.SetActive(false); // Hide photo Green
            padthaiPhoto.SetActive(false);
            somtumPhoto.SetActive(false);
            tomyumPhoto.SetActive(false);  
        }
    }
}
