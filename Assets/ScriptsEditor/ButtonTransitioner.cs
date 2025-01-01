using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonTransitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{

    public GameObject prefab;
    public GameObject hide;

    public string sceneName;

    public float countDown = 3;
    public Text textField;
    public string title;

    private int numCheck = 4;
    private int currentTime;

    AudioSource sound;

    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.gray;
    public Color32 m_DownColor = Color.white;

    private Image m_Iamge = null;



    public void OnPointerClick(PointerEventData eventData)
    {
  
        print("click");

        m_Iamge.color = m_HoverColor;

        if (sceneName == "Quit")
                    {
                            Application.Quit();
                        }

            Application.LoadLevel(sceneName);


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("down");

        m_Iamge.color = m_DownColor;

        prefab.SetActive(true);
        hide.SetActive(false);

        


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("enter");

        m_Iamge.color = m_HoverColor;
        
        //Application.LoadLevel(sceneName);
        


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("exit");

        m_Iamge.color = m_NormalColor;

       //Application.Quit();

        //countDown = 3;
        //numCheck = 4;
        //textField.text = title;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("up");

        m_Iamge.color = m_NormalColor;
    }




    //private void OnTriggerStay(Collider other)
    //{
    //    print("stay");

    //    if (other.tag == "Laser")
    //    {

    //        print("laser");
    //        countDown -= Time.deltaTime;
    //        currentTime = ((int)countDown + 1) % 60;
    //        textField.text = "" + currentTime;
    //        if (currentTime < numCheck)
    //        {
    //            numCheck = currentTime;

    //        }

    //        if (countDown < 0)
    //        {
    //            if (sceneName == "Quit")
    //            {
    //                Application.Quit();
    //            }
    //            else
    //            {
    //                Application.LoadLevel(sceneName);
    //            }
    //        }
    //    }
    //}



    // Start is called before the first frame update
    void Start()
    {
        m_Iamge = GetComponent<Image>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
