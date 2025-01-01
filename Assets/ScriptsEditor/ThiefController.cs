using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefController : MonoBehaviour
{
    //public GameObject serve4;
    public Transform teleportTarget4;
    public Transform teleportExit4;

    public static bool checkIsSit4 = false;
    public bool checkServe4 = false;
    public bool checkStatus = false; // Bug block

    private Animator anim;

    public ParticleSystem hitParticle;
    public ParticleSystem byeParticle;

    public GameObject normalFace;
    public GameObject dizzyFace;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Chair" && obj.gameObject.name == "Seat4" && !checkIsSit4 && !checkStatus) //Seat4
        {
            Debug.Log("Seat4 is true");

            gameObject.transform.position = teleportTarget4.transform.position;
            checkIsSit4 = true;
            checkStatus = true;
            checkServe4 = true;
        }
        
        else if (checkIsSit4 && (obj.gameObject.tag == "Dish" || obj.gameObject.tag == "Plate"))
        {
            
            hitParticle.Play(); // Damage particle
            anim.SetBool("isWeaponAttack", false);
            anim.SetBool("isDamage", true);
            normalFace.SetActive(false);
            dizzyFace.SetActive(true);
            Invoke("damageDelay",1);

            checkServe4 = false;
            checkIsSit4 = false;
            ServeSystem.checkServeDisc4 = false; //active GlobalserveDisc4
            ServeSystem.countDisc += 1;
            ScoreSystem.score += 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIsSit4)
        {
            //Debug.Log("ProcessSeat4");
            ServeSystem.checkServeDisc4 = true; //active GlobalserveDisc4

            anim.SetBool("isWeaponAttack", true); // Command Animation Attack
        }
    }

    public void damageDelay() // Animation unHappy delay
    {
        anim.SetBool("isDamage", false);
        gameObject.transform.position = teleportExit4.transform.position;
        Invoke("byePartDelay", 1.35f);
        Invoke("destroyGuestDelay", 1.8f);
    }


    public void byePartDelay()
    {
        byeParticle.Play(); // bye particle
    }

    public void destroyGuestDelay() // Destroy Guest
    {
        Destroy(gameObject);
    }
}
