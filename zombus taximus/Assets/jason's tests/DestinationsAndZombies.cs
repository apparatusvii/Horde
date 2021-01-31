using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationsAndZombies : MonoBehaviour
{
    public deliveryTimer deliveryScript;
    public GameObject playerCamera;
    public SpriteRenderer sprite;
    public AudioSource Pickup;

    void Start()
    {
      Pickup = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        ///reset everything before next delivery sequence
        if (deliveryScript.deliveryCounted == true)
        {
            gameObject.SetActive(false);
        }

        //for pickups only
        if (gameObject.CompareTag("pickup"))
        {
            //sprites face camera
            gameObject.transform.LookAt(playerCamera.transform);
            //sprite dissapears when picked up
            if (deliveryScript.pickedUp == true)
            {
                Pickup.Play();
                StartCoroutine (DisableSprite());
            }
        }
    }

    IEnumerator DisableSprite()
    {
      yield return new WaitForEndOfFrame();
      sprite.enabled = false;
    }


}
