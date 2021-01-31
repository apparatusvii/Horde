using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour
{

    public float startingTime2;

    private Text theText2;
    private Text theText;
    Transform parent;
    Transform child;
    public GameObject TimeSplat;



    //THIS IS THE CODE FOR THE TIMER THAT WAITS FOR GET READY
    //This is the 3,2,1 countdown

    // Use this for initialization
    void Start()
    {

        theText2 = GetComponent<Text>();
        StartCoroutine(Wait());
        TimeSplat = GameObject.Find("TimeSplat");

    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        print("waiting");

    }

    private void Update()
    {

        startingTime2 -= Time.deltaTime;

        theText2.text = "" + Mathf.Round(startingTime2);

        if (startingTime2 <= 0)
        {
            Destroy(GameObject.Find("TimeSplat"));
            Destroy(theText2 = GetComponent<Text>());

        }
    }
}



