using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServeSystem : MonoBehaviour
{
    public static bool checkServeDisc1 = false;
    public static bool checkServeDisc2 = false;
    public static bool checkServeDisc3 = false;
    public static bool checkServeDisc4 = false;

    public static int countDisc = 0;

    int targetDish;
    public GameObject canvasEndBest3;
    public GameObject canvasEndGood2;
    public GameObject canvasEndFair1;
    public GameObject canvasEndBad0;

    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "Level1(ThreeMenu)")
        {
            targetDish = 4;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (countDisc >= targetDish && sceneName == "Level1(ThreeMenu)") // SHOW Canvas End Stage
        {
            if (ScoreSystem.score >= 30)
            {
                canvasEndBest3.SetActive(true);
            }
            else if (ScoreSystem.score >= 20 && ScoreSystem.score < 30)
            {
                canvasEndGood2.SetActive(true);
            }
            else if (ScoreSystem.score >= 10 && ScoreSystem.score < 20)
            {
                canvasEndFair1.SetActive(true);
            }
            else if (ScoreSystem.score < 10)
            {
                canvasEndBad0.SetActive(true);
            }
        }
        
    }
}
