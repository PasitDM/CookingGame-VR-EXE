using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPickup : MonoBehaviour
{

    public GameObject objToCreate;
    public Transform posToCreate;
    bool check = false;

    float currentTime = 0;
    float startingTime = 3;

    private bool checkCollider = false;

    void Start()
    {
        currentTime = startingTime;
    }

    void OnTriggerEnter(Collider obj)
    {   //////// GreenCurry----------------------------------------GreenCurry--------------------------------------GreenCurry---------------------------------
        if (obj.gameObject.tag == "Pan" && gameObject.tag == "Kati" && !check) // Pan&Kati
        {
            //Debug.Log("Ingredients");
            checkCollider = true;
            startingTime = 2;
            currentTime = startingTime;
            check = true;
            //Invoke("destroyObject", 2);
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        if (obj.gameObject.tag == "Pan" && gameObject.tag == "Oil" && !check) // Pan&Oil
        {
            
            checkCollider = true;
            startingTime = 2;
            currentTime = startingTime;
            check = true;
            //Invoke("destroyObject", 2);
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        else if (obj.gameObject.tag == "CookGreen1Kati" && gameObject.tag == "Green" && !check) // PanKati&Green
        {
            checkCollider = true;
            startingTime = 2;
            currentTime = startingTime;
            check = true;
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        else if (obj.gameObject.tag == "CookGreen2Curry" && gameObject.tag == "Chick" && !check) // PanGreen&Chick
        {
            checkCollider = true;
            startingTime = 5;
            currentTime = startingTime;
            check = true;
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        else if (obj.gameObject.tag == "CookGreen3Chick" && gameObject.tag == "Eggplant" && !check) // PanChick&Eggplant
        {
            checkCollider = true;
            startingTime = 2;
            currentTime = startingTime;
            check = true;
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        else if (obj.gameObject.tag == "CookGreen4Eggplant" && gameObject.tag == "Chilli" && !check) // PanEggplant&Chilli
        {
            checkCollider = true;
            startingTime = 1;
            currentTime = startingTime;
            check = true;
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        else if (obj.gameObject.tag == "CookGreen5Chilli" && gameObject.tag == "Leave" && !check) // PanChilli&Leave
        {
            checkCollider = true;
            startingTime = 1;
            currentTime = startingTime;
            check = true;
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object       
        }
        //////// GreenCurry----------------------------------------GreenCurry--------------------------------------GreenCurry---------------------------------



        //////// PADTHAI---------------------------------------PADTHAI------------------------------------PADTHAI---------------------------------
        else if (obj.gameObject.tag == "PadCook1Oil" && gameObject.tag == "Shrimp" && !check) // PanKati&Shrimp
        {
            checkCollider = true;
            startingTime = 5;
            currentTime = startingTime;
            check = true;
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        else if (obj.gameObject.tag == "PadCook2Shrimp" && gameObject.tag == "Noodle" && !check) // PanKati&Noodle
        {
            checkCollider = true;
            startingTime = 5;
            currentTime = startingTime;
            check = true;
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        else if (obj.gameObject.tag == "PadCook3Noodle" && gameObject.tag == "Tofu" && !check) // PanKati&Tofu
        {
            checkCollider = true;
            startingTime = 1;
            currentTime = startingTime;
            check = true;
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        else if (obj.gameObject.tag == "PadCook4Tofu" && gameObject.tag == "Egg" && !check) // PanKati&Egg
        {
            checkCollider = true;
            startingTime = 2;
            currentTime = startingTime;
            check = true;
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        //////// PADTHAI---------------------------------------PADTHAI------------------------------------PADTHAI---------------------------------







        //////// SOMTUM----------------------------------------SOMTAM--------------------------------------SOMTAM---------------------------------
        if ((obj.gameObject.name == "MortarFirst" || obj.gameObject.name == "MortarFirst(Clone)") && gameObject.tag == "Chilli" && check == false) // Mortar&Chilli
        {
            checkCollider = true;
            startingTime = 1;
            currentTime = startingTime;
            check = true;
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
        else if ((obj.gameObject.name == "MortarChilli" || obj.gameObject.name == "mortarChilli(Clone)") && gameObject.tag == "Lime" && !check) // Lime
        {
            checkCollider = true;
            startingTime = 1;
            currentTime = startingTime;
            check = true;
        }
        else if ((obj.gameObject.name == "MortarChLime" || obj.gameObject.name == "MortarChLime(Clone)") && gameObject.tag == "Longbean" && !check) // Longbean
        {
            checkCollider = true;
            startingTime = 1;
            currentTime = startingTime;
            check = true;
        }
        else if ((obj.gameObject.name == "MortarLongbean" || obj.gameObject.name == "MortarLongbean(Clone)") && gameObject.tag == "Tomato" && !check) // Longbean
        {
            checkCollider = true;
            startingTime = 1;
            currentTime = startingTime;
            check = true;
        }
        else if ((obj.gameObject.name == "MortarTomato" || obj.gameObject.name == "MortarTomato(Clone)") && gameObject.tag == "Papaya" && !check) // Longbean
        {
            checkCollider = true;
            startingTime = 1;
            currentTime = startingTime;
            check = true;
        }
        //////// SOMTUM----------------------------------------SOMTAM--------------------------------------SOMTAM---------------------------------



    }

    void Update()
    {
        if (checkCollider == true)
        {
            timingFood();
        }
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }

    public void timingFood()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
            }
        }
        else
        {
            checkCollider = false;
            check = false;
            Destroy(gameObject);
            GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
    }
}