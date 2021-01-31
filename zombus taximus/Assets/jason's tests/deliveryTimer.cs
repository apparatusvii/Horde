using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deliveryTimer : MonoBehaviour
{
    public Text timerText, scoreTxt;
    public float startTime, currentTime;
    public bool timeIsTicking, deliveryCounted, pickedUp;
    public float score, customerCount;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        startTime = 30;
        timeIsTicking = false;
        deliveryCounted = false;
        pickedUp = false;
        score = 0;
        customerCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentTime);
        print("score " +score);

        timerText.text = currentTime.ToString("0.0");
        scoreTxt.text = ("Score: ")+ (score.ToString("0"));

        //if the countdown has been told to start, it will count down from the start time,
        //otherwise it will stay at the start time
        if (timeIsTicking == true)
        {
            currentTime -= 1 * Time.deltaTime;
        }
       // else currentTime = startTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup")) //picking up a zombie tells the countdown to start
        {
            timeIsTicking = true;
            pickedUp = true;          
        }

        if (other.gameObject.CompareTag("destination")&&pickedUp==true)//when you reach the destination, the delivery gets counted
        {
            pickedUp = false;
            deliveryCounted = true;
            customerCount++;     ////////////////////if you want to record how many customers here ya go 

            print("delivered");            
            StartCoroutine(stopTheCount());
            score = score + 10 * currentTime;
            currentTime = currentTime + 15;
        }
    }

    IEnumerator stopTheCount()//stops score from being calculated every frame
    {
        yield return new WaitForEndOfFrame();
        deliveryCounted = false;
        score = score * 1;
        print("delivery counted");
    }
}
