using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    public deliveryTimer deliveryScript;

    public GameObject[] zombies = new GameObject[4];
    public GameObject[] destinations = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        GetRandoms();
    }

    // Update is called once per frame
    void Update()
    {
        if (deliveryScript.deliveryCounted == true)
        {
            StartCoroutine(WaitJustOneFramePls());   
        }
    }

    void GetRandoms()
    {               
        GameObject newDestination = destinations[Random.Range(0, destinations.Length)];
        GameObject newZombie = zombies[Random.Range(0, zombies.Length)];
        newDestination.SetActive(true);
        newZombie.SetActive(true); 
    }

    IEnumerator WaitJustOneFramePls()
    {
        yield return new WaitForEndOfFrame();
        GetRandoms();
    }
}
