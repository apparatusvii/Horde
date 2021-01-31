using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Highscore2 : MonoBehaviour
{

    public int score = 0;


    // Use this for initialization
    void Start()
    {

        int highscore = PlayerPrefs.GetInt("highscore");
        print(PlayerPrefs.GetInt("highscore") + "score ");
        if (highscore < score)
        {
            // saves the value of "score" into the highscore field
            PlayerPrefs.SetInt("highscore", score);

        }

    }
}