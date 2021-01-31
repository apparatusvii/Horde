using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    //made this public so you can see in inspector
    //drag the health slider in this bitch so it can access 
    //scene management without causing BadFood to trigger it

    public Slider healthBar;


    void Start()
    {
        Debug.Log("Yeet this bitch is online hoe");
        GameObject.Find("Health Slider");
    }

    private void yeet()

    {
        if (healthBar.value <= 0)
        {
            SceneManager.LoadScene("GameOver");
            PlayerPrefs.SetInt("highscore",GameManager.instance.scoreValue);
            print(PlayerPrefs.GetInt("highscore")+ " end score");
        }
    }
}
       



    //hallelujah it works, needed UI manager









