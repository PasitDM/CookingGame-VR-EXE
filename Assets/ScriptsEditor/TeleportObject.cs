using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportObject : MonoBehaviour
{
    public GameObject guestOrderSit;
    public Transform posToCreate;
    public bool checkIsSit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Chair")
        {
            Destroy(gameObject);
            GameObject i = Instantiate(guestOrderSit, posToCreate.position, posToCreate.rotation);
            checkIsSit = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
