using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliveryTimer : MonoBehaviour
{
    
    public float startTime, currentTime;
    public bool timeIsTicking;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        startTime = 30;
        timeIsTicking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentTime);

        //if the countdown has been told to start, it will count down from the start time,
        //otherwise it will stay at the start time
        if (timeIsTicking == true)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        else currentTime = startTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup")) //picking up a zombie tells the countdown to start
        {
            timeIsTicking = true;            
        }

        if (other.gameObject.CompareTag("destination"))//when you reach the destination, the timer stops counting down
        {
            timeIsTicking = false;           
        }
    }
}
