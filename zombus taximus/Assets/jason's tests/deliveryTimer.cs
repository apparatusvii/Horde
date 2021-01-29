using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deliveryTimer : MonoBehaviour
{
    public Text timerText, scoreTxt;
    public float startTime, currentTime;
    public bool timeIsTicking, deliveryCounted;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        startTime = 30;
        timeIsTicking = false;
        deliveryCounted = false;
        score = 0;
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
        }

        if (other.gameObject.CompareTag("destination"))//when you reach the destination, the timer stops counting down
        {
            //timeIsTicking = false;
            deliveryCounted = true;
            print("delivered");
            print("AAAAAAAAAAAAAAAAAAAAAAAA");
            StartCoroutine(stopTheCount());
            score = score + 100 * currentTime;
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
