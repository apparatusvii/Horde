using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public deliveryTimer deliveryScript;
    public GameObject passenger, destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        passenger = GameObject.FindGameObjectWithTag("pickup");
        destination = GameObject.FindGameObjectWithTag("destination");

        if (deliveryScript.pickedUp == false)
        {
            gameObject.transform.LookAt(passenger.transform);
        }
        if(deliveryScript.pickedUp==true)
        {
            gameObject.transform.LookAt(destination.transform);
        }
    }
}
