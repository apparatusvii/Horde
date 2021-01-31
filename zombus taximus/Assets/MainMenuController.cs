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
    public GameObject buttonGroup1, buttonGroup2;
    public void Start()
    {
        highscore.text = " Fare: " + PlayerPrefs.GetInt("highscore");
        customer.text = " Total customers: " + PlayerPrefs.GetInt("customer");
        buttonGroup1.SetActive(true);
        buttonGroup2.SetActive(false);
    }


    public void playGame()
    {
        //SceneManager.LoadScene("Game_Scene");
        buttonGroup1.SetActive(false);
        buttonGroup2.SetActive(true);
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

    public void E20()
    {
      SceneManager.LoadScene("Game_Scene E20");
    }
    public void GM()
    {
      SceneManager.LoadScene("Game_Scene GM");
    }
    public void KEI()
    {
      SceneManager.LoadScene("Game_Scene KEI");
    }
}
