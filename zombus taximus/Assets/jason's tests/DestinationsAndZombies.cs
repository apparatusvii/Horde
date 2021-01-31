using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationsAndZombies : MonoBehaviour
{
    public deliveryTimer deliveryScript;
    public GameObject playerCamera;
    public SpriteRenderer sprite;


    // Update is called once per frame
    void Update()
    {


        ///reset everything before next delivery sequence
        if (deliveryScript.deliveryCounted == true)
        {
            gameObject.SetActive(false);

            Debug.Log("Sound off");
        }

        //for pickups only
        if (gameObject.CompareTag("pickup"))
        {
            //sprites face camera
            gameObject.transform.LookAt(playerCamera.transform);
            //sprite dissapears when picked up
            if (deliveryScript.pickedUp == true)
            {
              sprite.enabled = false;

            }
        }
    }
}
