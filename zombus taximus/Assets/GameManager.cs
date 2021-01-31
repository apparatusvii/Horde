using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int customerC = 0;
    public Text timerText, scoreTxt;
    public Text highscore;
    public Text customer;



        private void Update()
    {
        scoreTxt.text = "highScore"  + score;
        customer.text = "customer" + customerC;
    }

    public void GameOver ()

    {
        PlayerPrefs.SetInt("highscore", score);
        PlayerPrefs.SetInt("customer", customerC);
        SceneManager.LoadScene("GameOver");
    }
}

