using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRemovePaste : MonoBehaviour
{
    public GameObject objToCreate;
    public Transform posToCreate;
    public GameObject objToCreateOther;
    public bool check = false;

    void Start()
    {

    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "CookGreen6Leave" && gameObject.tag == "Dish" && !check)
        {
            check = true;
            Destroy(gameObject);
            GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); 
        }

        if (obj.gameObject.tag == "PadCook5Egg" && gameObject.tag == "Plate" && !check)
        {
            check = true;
            Destroy(gameObject);
            GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation); 
        }

        if (obj.gameObject.tag == "Mortar6Finish" && gameObject.tag == "Plate" && !check) // Serve
        {
            objToCreate = objToCreateOther; // Change to SomtumFull
            check = true;
            Destroy(gameObject);
            GameObject i = Instantiate(objToCreate, posToCreate.position, posToCreate.rotation);
        }
    }
    void Update()
    {
        
    }
}