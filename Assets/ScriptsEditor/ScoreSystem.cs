using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;
    public Text scoreThreeStarText;
    public Text scoreTwoStarText;
    public Text scoreOneStarText;
    public Text scoreZeroStarText;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "" + score;
        scoreThreeStarText.GetComponent<Text>().text = "" + score;
        scoreTwoStarText.GetComponent<Text>().text = "" + score;
        scoreOneStarText.GetComponent<Text>().text = "" + score;
        scoreZeroStarText.GetComponent<Text>().text = "" + score;
    }
}
