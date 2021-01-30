using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationsAndZombies : MonoBehaviour
{
    public deliveryTimer deliveryScript;
    

    // Update is called once per frame
    void Update()
    {
         if (deliveryScript.deliveryCounted == true)
        {
            gameObject.SetActive(false);
        }
    }
}
