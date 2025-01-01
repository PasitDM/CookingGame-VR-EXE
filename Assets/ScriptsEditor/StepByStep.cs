using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepByStep : MonoBehaviour
{

    public GameObject objToCreate;
    public Transform posToCreate;
    public GameObject objToCreateOther1;

    public bool check = false;
    public bool resetPan = false;

    float currentTime = 0;
    float startingTime = 3;

    [SerializeField] Text countdownFood;

    private bool checkCollider = false;
    
    void Start()
    {
        currentTime = startingTime;
    }

    void OnTriggerEnter(Collider obj)
    {
        if (gameObject.tag == "Pan" && obj.gameObject.tag == "Kati" && !check) // Kati
        {
            checkCollider = true;
            startingTime = 2;
            currentTime = startingTime;
            check = true;
            resetPan = false;
        }


        if (gameObject.tag == "Pan" && obj.gameObject.tag == "Oil" && !check) // Oil
        {
            objToCreate = objToCreateOther1;
            checkCollider = true;
            startingTime = 2;
            currentTime = startingTime;
            check = true;
            resetPan = false;
        }


        else if (gameObject.tag == "CookGreen1Kati" && obj.gameObject.tag == "Green" && !check) // GreenPowder
        {
            Debug.Log("collider Kati");
            checkCollider = true;
            startingTime = 2;
            currentTime = startingTime;
            check = true;
        }
        else if (gameObject.tag == "CookGreen2Curry" && obj.gameObject.tag == "Chick" && !check) // Chick
        {
            checkCollider = true;
            startingTime = 5;
            currentTime = startingTime;
            check = true;  
        }
        else if (gameObject.tag == "CookGreen3Chick" && obj.gameObject.tag == "Eggplant" && !check) // Eggplant
        {
            checkCollider = true;
            startingTime = 2;
            currentTime = startingTime;
            check = true;
        }
        else if (gameObject.tag == "CookGreen4Eggplant" && obj.gameObject.tag == "Chilli" && !check) // Chilli
        {
            checkCollider = true;
            startingTime = 0;
            currentTime = startingTime;
            check = true;
        }
        else if (gameObject.tag == "CookGreen5Chilli" && obj.gameObject.tag == "Leave" && !check) // Leave
        {
            checkCollider = true;
            startingTime = 0;
            currentTime = startingTime;
            check = true;
        }

        else if (gameObject.tag == "CookGreen6Leave" && obj.gameObject.tag == "Dish" && !resetPan) // ServeGreen
        {
            check = false;
            resetPan = true;
            Debug.Log("collider dish");
            Destroy(gameObject);
            GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }



        ////////----STEPBYSTEP---------PADTHAI -----------PADTHAI----------PADTHAI-----------PADTHAI----------STEPBYSTEP---------------------------
        else if (gameObject.tag == "PadCook1Oil" && obj.gameObject.tag == "Shrimp" && !check) // Shrimp
        {
            checkCollider = true;
            startingTime = 5;
            currentTime = startingTime;
            check = true;
            
        }
        else if (gameObject.tag == "PadCook2Shrimp" && obj.gameObject.tag == "Noodle" && !check) // Noodle
        {
            checkCollider = true;
            startingTime = 5;
            currentTime = startingTime;
            check = true;
            
        }
        else if (gameObject.tag == "PadCook3Noodle" && obj.gameObject.tag == "Tofu" && !check) // Tofu
        {
            checkCollider = true;
            startingTime = 1;
            currentTime = startingTime;
            check = true;
            
        }
        else if (gameObject.tag == "PadCook4Tofu" && obj.gameObject.tag == "Egg" && !check) // Egg
        {
            checkCollider = true;
            startingTime = 2;
            currentTime = startingTime;
            check = true;
            
        }
        else if (gameObject.tag == "PadCook5Egg" && obj.gameObject.tag == "Plate" && !resetPan) // ServeGreen
        {
            check = false;
            resetPan = true;
            Debug.Log("collider dish");
            Destroy(gameObject);
            GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }


    }
    void Update()
    {
        if (checkCollider == true)
        {
            timingFood();
        }
    }

    public void timingFood()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownFood.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
            }
        }

        else
        {
            countdownFood.text = "";
            checkCollider = false;
            check = false;
            Destroy(gameObject);
            GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
    }
}