using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void changeToScene (int changeTheScene)
    {
        ScoreSystem.score = 0;
        ServeSystem.countDisc = 0;
        SceneManager.LoadScene(changeTheScene);
    }    

    public void exitGame()
    {
        Application.Quit();
    }
}
