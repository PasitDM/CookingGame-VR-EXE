using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 80;

    public GameObject serve1;

    public Transform teleportTarget1;
    public Transform teleportExit1;
    
    [SerializeField] Text countdownText1;

    public static bool checkIsSit1 = false;
    public bool checkServe1 = false;
    public bool checkStatus = false; // Bug block

    private Animator anim;

    public ParticleSystem happyParticle;
    public ParticleSystem happy1Particle;
    public ParticleSystem sadParticle;
    public ParticleSystem byeParticle;
    public GameObject laughFace;
    public GameObject smileFace;
    public GameObject pokerFace;
    public GameObject angryFace;

    // Start is called before the first frame update
    void Start()
    {
        
        currentTime = startingTime;
        anim = GetComponent<Animator>();
        happyParticle.Stop();
        happy1Particle.Stop();
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Chair" && obj.gameObject.name == "Seat1" && !checkIsSit1 && !checkStatus) //Seat1
        {
            Debug.Log("Seat1 is true");
            
            gameObject.transform.position = teleportTarget1.transform.position;    
            checkIsSit1 = true;
            checkStatus = true;
            checkServe1 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIsSit1)
        {
            //Debug.Log("ProcessSeat1");
            ServeSystem.checkServeDisc1 = true; //active GlobalserveDisc1
            serve1.SetActive(true); //active serveDisc1
      
            currentTime -= 1 * Time.deltaTime;
            countdownText1.text = currentTime.ToString("0");

            if (currentTime >= 45 && currentTime <= 60)
            {

            }
            else if (currentTime >= 30 && currentTime < 45)
            {
                smileFace.SetActive(true);
                laughFace.SetActive(false);
            }
            else if (currentTime >= 10 && currentTime < 30)
            {
                pokerFace.SetActive(true);
                smileFace.SetActive(false);
            }
            else if (currentTime >= 0 && currentTime < 10)
            {
                angryFace.SetActive(true);
                pokerFace.SetActive(false);
            }

            if (currentTime <= 0) // If guest time out
            {
                currentTime = 0;
                countdownText1.text = "";

                ServeSystem.checkServeDisc1 = false;
                serve1.SetActive(false);

                checkIsSit1 = false;
                checkStatus = false;
                checkServe1 = false;
                RandomMenu.isGreencurry = false;
                RandomMenu.isPadthai = false;
                RandomMenu.isSomtam = false;
                RandomMenu.isTomYumGoong = false;
                
                RandomMenu.isGreencurryPassServe = false;
                RandomMenu.isPadthaiPassServe = false;
                RandomMenu.isSomtamPassServe = false;
                RandomMenu.isTomYumGoongPassServe = false;

                ServeSystem.countDisc += 1;

                anim.SetBool("isWeaponAttack", true); // Command Animation Fail
                sadParticle.Play(); // Broken heart
                Invoke("weaponAttackDelay", 2); 
            }
        }
        else if (checkServe1 && checkStatus && !checkIsSit1) // Guest get food
        {
            Debug.Log("Guest going out1");
            ServeSystem.checkServeDisc1 = false;
            serve1.SetActive(false);

            ServeSystem.countDisc += 1;
            countdownText1.text = "";

            scoreFace(); // score++

            checkIsSit1 = false;
            checkStatus = false;
            checkServe1 = false;

            Debug.Log("timer");
            anim.SetBool("isVictory", true); // Command Animation Victory
            happyParticle.Play();
            happy1Particle.Play();
            Invoke("victoryDelay", 5);       
        }         
    }

    public void victoryDelay() // Animation Victory delay
    {
        happyParticle.Play();
        happy1Particle.Play();
        anim.SetBool("isVictory", false);
        gameObject.transform.position = teleportExit1.transform.position;
        anim.SetBool("isBye", true);
        Invoke("byePartDelay", 1f); 
        Invoke("destroyGuestDelay", 1.8f);
    }

    public void weaponAttackDelay() // Animation unHappy delay
    {
        anim.SetBool("isWeaponAttack", false);
        anim.SetBool("isFail", true);
        sadParticle.Play(); // Broken heart
        gameObject.transform.position = teleportExit1.transform.position;
        Invoke("failDelay", 4);
    }

    public void failDelay() // Animation Fail delay
    {
        anim.SetBool("isFail", false);
        anim.SetBool("isBye", true);
        Invoke("byePartDelay", 1.2f); 
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

    public void scoreFace() // SCORE
    {
        if (laughFace.activeInHierarchy)
        {
            ScoreSystem.score += 10;
        }
        else if (smileFace.activeInHierarchy)
        {
            ScoreSystem.score += 5;
        }
        else if (pokerFace.activeInHierarchy)
        {
            ScoreSystem.score += 2;
        }
        else if (angryFace.activeInHierarchy)
        {
            ScoreSystem.score += 1;
        }
    }
}
