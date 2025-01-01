using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimeTwo : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 80;

    public GameObject serve2;

    public Transform teleportTarget2;
    public Transform teleportExit2;

    [SerializeField] Text countdownText2;

    public static bool checkIsSit2 = false;
    public bool checkServe2 = false;
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
        if (obj.gameObject.tag == "Chair" && obj.gameObject.name == "Seat2" && !checkIsSit2 && !checkStatus) // Seat2
        {
            Debug.Log("Seat2 is true");
            
            gameObject.transform.position = teleportTarget2.transform.position;
            checkIsSit2 = true;
            checkStatus = true;
            checkServe2 = true;
}
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIsSit2)
        {
            //Debug.Log("ProcessSeat2");
            ServeSystem.checkServeDisc2 = true; //active GlobalserveDisc2
            serve2.SetActive(true); //active serveDisc2

            currentTime -= 1 * Time.deltaTime;
            countdownText2.text = currentTime.ToString("0");

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
                countdownText2.text = "";

                ServeSystem.checkServeDisc2 = false;
                serve2.SetActive(false);

                checkIsSit2 = false;
                checkStatus = false;
                checkServe2 = false;
                TwoRandomMenu.isGreencurry = false;
                TwoRandomMenu.isPadthai = false;
                TwoRandomMenu.isSomtam = false;
                TwoRandomMenu.isTomYumGoong = false;

                TwoRandomMenu.isGreencurryPassServe = false;
                TwoRandomMenu.isPadthaiPassServe = false;
                TwoRandomMenu.isSomtamPassServe = false;
                TwoRandomMenu.isTomYumGoongPassServe = false;

                ServeSystem.countDisc += 1;

                anim.SetBool("isWeaponAttack", true); // Command Animation Fail
                sadParticle.Play(); // Broken heart
                Invoke("weaponAttackDelay", 2);
            }
        }
        else if (checkServe2 && checkStatus && !checkIsSit2)
        {
            Debug.Log("Guest going out2");
            ServeSystem.checkServeDisc2 = false;
            serve2.SetActive(false);

            ServeSystem.countDisc += 1;
            countdownText2.text = "";

            scoreFace(); // score++

            checkIsSit2 = false;
            checkStatus = false;
            checkServe2 = false;

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
        gameObject.transform.position = teleportExit2.transform.position;
        anim.SetBool("isBye", true);
        Invoke("byePartDelay", 1f);
        Invoke("destroyGuestDelay", 1.8f);
    }

    public void weaponAttackDelay() // Animation unHappy delay
    {
        anim.SetBool("isWeaponAttack", false);
        anim.SetBool("isFail", true);
        sadParticle.Play(); // Broken heart
        gameObject.transform.position = teleportExit2.transform.position;
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
