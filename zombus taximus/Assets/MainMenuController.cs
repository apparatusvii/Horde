using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Text highscore;
    public Text customer;

    public void Start()
    {
        highscore.text = " Fare: " + PlayerPrefs.GetInt("highscore");
        customer.text = " Total customers: " + PlayerPrefs.GetInt("customer");
    }


    public void playGame()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
