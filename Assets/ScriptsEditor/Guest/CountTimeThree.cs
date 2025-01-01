using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimeThree : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 80;

    public GameObject serve3;

    public Transform teleportTarget3;
    public Transform teleportExit3;

    [SerializeField] Text countdownText3;

    public static bool checkIsSit3 = false;
    public bool checkServe3 = false;
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
        if (obj.gameObject.tag == "Chair" && obj.gameObject.name == "Seat3" && !checkIsSit3 && !checkStatus) // Seat3
        {
            Debug.Log("Seat3 is true");

            gameObject.transform.position = teleportTarget3.transform.position;
            checkIsSit3 = true;
            checkStatus = true;
            checkServe3 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIsSit3)
        {
            //Debug.Log("ProcessSeat3");
            ServeSystem.checkServeDisc3 = true; //active GlobalserveDisc3
            serve3.SetActive(true); //active serveDisc3

            currentTime -= 1 * Time.deltaTime;
            countdownText3.text = currentTime.ToString("0");

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
                countdownText3.text = "";

                ServeSystem.checkServeDisc3 = false;
                serve3.SetActive(false);

                checkIsSit3 = false;
                checkStatus = false;
                checkServe3 = false;
                ThreeRandomMenu.isGreencurry = false;
                ThreeRandomMenu.isPadthai = false;
                ThreeRandomMenu.isSomtam = false;
                ThreeRandomMenu.isTomYumGoong = false;

                ThreeRandomMenu.isGreencurryPassServe = false;
                ThreeRandomMenu.isPadthaiPassServe = false;
                ThreeRandomMenu.isSomtamPassServe = false;
                ThreeRandomMenu.isTomYumGoongPassServe = false;

                ServeSystem.countDisc += 1;

                anim.SetBool("isWeaponAttack", true); // Command Animation Fail
                sadParticle.Play(); // Broken heart
                Invoke("weaponAttackDelay", 2);
            }
        }
        else if (checkServe3 && checkStatus && !checkIsSit3)
        {
            Debug.Log("Guest going out3");
            ServeSystem.checkServeDisc3 = false;
            serve3.SetActive(false);

            ServeSystem.countDisc += 1;
            countdownText3.text = "";

            scoreFace(); // score++

            checkIsSit3 = false;
            checkStatus = false;
            checkServe3 = false;

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
        gameObject.transform.position = teleportExit3.transform.position;
        anim.SetBool("isBye", true);
        Invoke("byePartDelay", 1f);
        Invoke("destroyGuestDelay", 1.8f);
    }

    public void weaponAttackDelay() // Animation unHappy delay
    {
        anim.SetBool("isWeaponAttack", false);
        anim.SetBool("isFail", true);
        sadParticle.Play(); // Broken heart
        gameObject.transform.position = teleportExit3.transform.position;
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
