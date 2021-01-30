using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class NPC_AI : MonoBehaviour
{
    [Header("NPC")]
    public Transform NPC;

    [Header("NPC Movement"), Tooltip("The variables needed for moving the NPC")]
    public NavMeshAgent nPCAgent;
    Vector3[] mapBounds;
    Vector3[] centralPoints;


    [Header("Senses"), Tooltip("The variables needed for the AI to acknowledge surroundings")]
    public Transform centerPoint;
    public float obstacleCheckRadius;
    public LayerMask obstaclesLayer;
    private bool touchingObstacles;
    [Space(10)]
    public float playerCheckRadius;
    public LayerMask playerLayer;
    public GameObject player;
    private bool touchingPlayer;


    [Header("Timing Variables"), Tooltip("The minimum and maximum wait times before the NPC moves")]

    [Range(0, 120)]
    public float minWaitTime;

    [Range(0, 120)]
    public float maxWaitTime;

    [Range(0.05f, 0.3f)]
    public float rotationTime;

    [Header("References")]
    public Animator nPCAnimator;
    DetectPlayer detectPlayer;
    ThirdPersonController thirdPersonController;
    private bool paused;

    void Start()
    {
        //This is the bounds of the map in which the NPC can move
        mapBounds = new Vector3[]
        {
        new Vector3(Random.Range(-4,4), 0, 0),
        new Vector3(0, 0, Random.Range(-3,4)),
        new Vector3(Random.Range(-3,3), 0, Random.Range(-3,4))
        };

        centralPoints = new Vector3[]
        {
        new Vector3(Random.Range(-1.85f,2), 0, 0),
        new Vector3(0, 0, Random.Range(-1,1)),
        new Vector3(Random.Range(-1.85f,2), 0, Random.Range(-1,1))
        };

        detectPlayer = GetComponent<DetectPlayer>();
        thirdPersonController = player.GetComponent<ThirdPersonController>();
        
        StartCoroutine(MoveDelay());
    }

    void Update()
    {
        CheckForPlayer();
        PlayAnimations();
    }

    IEnumerator MoveDelay()
    {
        int i = 0;
        while(i < 1)
        {
            Debug.Log("Waiting");
            while (!paused)
            { 
                yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
                if (!paused)
                {
                    MoveToNextPoint();
                }
                yield return null;
            }
            while (paused)
            {
                yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
                yield return null;
            }
            yield return null;
        }
    }

    //Moves the NPC in any direction within the given vectors(bounds)
    void MoveToNextPoint()
    {
        Debug.Log("Walking");
        Vector3 withinBounds = mapBounds[Random.Range(0, mapBounds.Length)];
        Vector3 centralBounds = centralPoints[Random.Range(0, centralPoints.Length)];
        touchingPlayer = detectPlayer.inRange;
        touchingObstacles = Physics.CheckSphere(centerPoint.position, obstacleCheckRadius, obstaclesLayer);


        if (!touchingObstacles && !touchingPlayer)
        {
            nPCAgent.destination = withinBounds;
            transform.rotation = Quaternion.LookRotation(withinBounds - transform.position);
        }
        else
        {
            nPCAgent.destination = centralBounds;
            transform.rotation = Quaternion.LookRotation(withinBounds - transform.position);
        }
    }

    void CheckForPlayer()
    {
        var allParticipants = new List<ThirdPersonController>(FindObjectsOfType<ThirdPersonController>());
            var target = allParticipants.Find(delegate (ThirdPersonController p) {
                return p.playerController == true && // has a controller?
                (p.transform.position - this.transform.position)// is in range?
                .magnitude <= detectPlayer.interactionRadius;
            });

        if (target != null)
        {
            paused = true;
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            //NPC.LookAt(player.transform);
            nPCAnimator.SetBool("isSweeping", true);
        }
        else
        {
            paused = false;
        }
    }

    //Plays the animations corresponding with this NPC
    void PlayAnimations()
    {
        if (nPCAgent.velocity.magnitude > 0.25)
        {
            //Play Walking Animation
            nPCAnimator.SetBool("isSweeping", false);
        }
        else
        {
            //Play Idle Animation
            nPCAnimator.SetBool("isSweeping", true);
        }
    }

    //Draws the wire sphere in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(centerPoint.transform.position, obstacleCheckRadius);
    }
}
