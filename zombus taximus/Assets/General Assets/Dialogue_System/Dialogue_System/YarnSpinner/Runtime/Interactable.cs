using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public LayerMask playerLayer;
    public Transform centerPoint;
    public float interactionRadius;

    [HideInInspector]
    public bool inRange = false;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(centerPoint.position, interactionRadius);
    }

}
