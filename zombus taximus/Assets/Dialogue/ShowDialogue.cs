using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class ShowDialogue : MonoBehaviour
{
    public GameObject dialogueDisplay;
    public Transform dialogueDisplayParent;
    public GameObject player;
    public LayerMask playerLayer;
    public Transform centerPoint;
    public float interactionRadius;

    [HideInInspector]
    public bool inRange = false;
    public Dialogue dialogue;


    // Update is called once per frame
    void Start()
    {
        //StartCoroutine(Begin());
    }

    // IEnumerator Begin()
    // {
    //     //I'm brain dead and this is extremely bad practice. I'm going to comment it out because it crashed my unity. 
    //     //don't use while(true)
    //     //I just need a way to start the dialogue when in range
    //     //everything else is pretty self explanatory
    //     print("Pls start");
    //     // while (true)
    //     // {
    //     //     InRange();
    //     // }
    //     return new WaitForSeconds(1);
    // }
    public void InRange()
    {
        inRange = Physics.CheckSphere(this.centerPoint.position, interactionRadius, playerLayer);
        if(inRange)
        {
            dialogueDisplay.SetActive(true);
            dialogueDisplay.transform.position = dialogueDisplayParent.transform.position;
            StartCoroutine(dialogue.Type());
        }
        else 
        {
            dialogueDisplay.SetActive(false);
            StopCoroutine(dialogue.Type());
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(centerPoint.position, interactionRadius);
    }
    
}
