using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public Text timerText, scoreTxt;
    public Text highScore;



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

        private void Update()
    {
        scoreTxt.text = "highScore"  +score;
    }

    public void GameOver ()

    {
        PlayerPrefs.SetInt("highscore", score);
            SceneManager.LoadScene("GameOver");
    }
}
