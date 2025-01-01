using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MortarStep : MonoBehaviour
{
    public GameObject mortar1First;
    public GameObject mortar2Chilli;
    public GameObject mortar22ChilliSmash;
    public GameObject mortar3ChLime;
    public GameObject mortar4Longbean;
    public GameObject mortar5Tomato;
    public GameObject mortar6Papaya;
    public GameObject mortar7Finish;

    public GameObject mortarAlltoDelete;
    public GameObject mortarAllNew;
    public Transform posToCreate;

    public bool check = false;
    public bool resetMortar = false;

    float currentTime = 0;
    float startingTime = 1;
    [SerializeField] Text countdownFood;

    private int valueSmash = 10;
    private bool checkSmash = false;
    private bool checkCollider = false;

    //public ParticleSystem particleSystem;

    void Start()
    {
        currentTime = startingTime;
    }

    void OnTriggerEnter(Collider obj)
    {
        
        if (gameObject.tag == "Mortar" && obj.gameObject.tag == "Chilli" && !check) // Chilli
        {
            Debug.Log("MortarFirst");
            //check = true;
            gameObject.transform.position = posToCreate.transform.position;
            mortar1First.SetActive(false);
            mortar2Chilli.SetActive(true);
            
        }
        else if (gameObject.tag == "Mortar1Chilli" && obj.gameObject.tag == "Lime" && !check) // Lime
        {
            
            //check = true;
            gameObject.transform.position = posToCreate.transform.position;
            mortar2Chilli.SetActive(false);
            mortar3ChLime.SetActive(true);
            
        }
        else if (gameObject.tag == "Mortar1.5Chilli" && obj.gameObject.tag == "Pestle" && !check) // CountSmask to ChilliAlittle
        {
            checkSmash = true;
            countdownFood.text = valueSmash.ToString("0");
            //valueSmash--;
            if (valueSmash <= 0)
            {
                valueSmash = 10;
                //check = true;
                gameObject.transform.position = posToCreate.transform.position;
                mortar2Chilli.SetActive(false);
                mortar22ChilliSmash.SetActive(true);
            }
        }
        else if (gameObject.tag == "Mortar2Lime" && obj.gameObject.tag == "Longbean" && !check) // Longbean
        {
            //check = true;
            gameObject.transform.position = posToCreate.transform.position;
            mortar3ChLime.SetActive(false);
            mortar4Longbean.SetActive(true);
        }
        else if (gameObject.tag == "Mortar3Longbean" && obj.gameObject.tag == "Tomato" && !check) // Tomato
        {
            //check = true;
            gameObject.transform.position = posToCreate.transform.position;
            mortar4Longbean.SetActive(false);
            mortar5Tomato.SetActive(true);
        }
        else if (gameObject.tag == "Mortar4Tomato" && obj.gameObject.tag == "Papaya" && !check) // Papaya
        {

            // check = true;
            gameObject.transform.position = posToCreate.transform.position;
            mortar5Tomato.SetActive(false);
            mortar6Papaya.SetActive(true);
        }
        else if (gameObject.tag == "Mortar5Papaya" && obj.gameObject.tag == "Pestle" && !check) // CountSmash
        {
            gameObject.transform.position = posToCreate.transform.position;
            checkSmash = true;
            countdownFood.text = valueSmash.ToString("0");
            //valueSmash--;
            if (valueSmash <= 0)
            {
                valueSmash = 10;
               // check = true;
                mortar6Papaya.SetActive(false);
                mortar7Finish.SetActive(true);
            }
        }
        else if (gameObject.tag == "Mortar6Finish" && obj.gameObject.tag == "Plate" && !check) // Serve
        {
            // check = true;
            gameObject.transform.position = posToCreate.transform.position;
            mortar7Finish.SetActive(false);
            mortar1First.SetActive(true);

           // Destroy(mortarAlltoDelete);
           // GameObject i = Instantiate(mortarAllNew, posToCreate.position, posToCreate.rotation);
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (gameObject.tag == "Mortar5Papaya" && obj.gameObject.tag == "Pestle" && checkSmash) // Longbean
        {
            checkSmash = false;
            countdownFood.text = valueSmash.ToString("0");
            valueSmash--;

            if (valueSmash <= 0)
            {
                valueSmash = 10;
               // check = true;
                mortar6Papaya.SetActive(false);
                mortar7Finish.SetActive(true);
            }
        }
        else if (gameObject.tag == "Mortar1Chilli" && obj.gameObject.tag == "Pestle" && checkSmash) // CountSmask to ChilliAlittle
        {
            checkSmash = false;
            countdownFood.text = valueSmash.ToString("0");
            valueSmash--;

            if (valueSmash <= 0)
            {
                valueSmash = 10;
               // check = true;
                mortar2Chilli.SetActive(false);
                mortar3ChLime.SetActive(true);
            }
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
            //Destroy(gameObject);
            //GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); // spawn object
        }
    }

    public void countSmash()
    {

    }
}
