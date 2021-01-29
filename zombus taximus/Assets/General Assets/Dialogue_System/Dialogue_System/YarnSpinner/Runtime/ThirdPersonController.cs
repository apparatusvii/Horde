using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


namespace Yarn.Unity
{
    public class ThirdPersonController : MonoBehaviour
    {
        [Header("Player Movement")]
        public CharacterController playerController;

        [Range(50, 150)]
        public float moveSpeed;

        [Range(0.1f, 0.5f)]
        public float rotateSpeed;
        Vector3 move = Vector3.zero;

        [Header("Interaction")]
        public Transform playerInteractionPoint;

        [Range(1, 2)]
        public float interactionRadius;

        [HideInInspector]
        public int nodeCounter = 0;
        private bool limitReached;
        private bool inRange;
       
        [Header("References")]
        public Animator playerAnimator;
        DialogueRunner dialogueRunner;

        void Start()
        {
            dialogueRunner = FindObjectOfType<DialogueRunner>();
        }
        private void Update()
        {
            RotatePlayer();
            Animations();
            CheckForNearbyNPC();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }
        void MovePlayer()
        {
            var speed = moveSpeed * Time.deltaTime;
            move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            if (!Input.GetKey(KeyCode.C))
            {
                playerController.SimpleMove(move.normalized * speed);
            }
        }

        void RotatePlayer()
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
              transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), rotateSpeed);
            }
        }
        void Animations()
        {
            if (Input.GetAxisRaw("Horizontal") >= 0.1 || Input.GetAxisRaw("Horizontal") < 0)
            {
                playerAnimator.SetBool("isIdling", false);
                playerAnimator.SetBool("isRunning", true);
            }
            else if (Input.GetAxisRaw("Horizontal") == 0)
            {
                playerAnimator.SetBool("isIdling", true);
                playerAnimator.SetBool("isRunning", false);
            }

            if (Input.GetAxisRaw("Vertical") >= 0.1 || Input.GetAxisRaw("Vertical") < 0)
            {
                playerAnimator.SetBool("isIdling", false);
                playerAnimator.SetBool("isRunning", true);
            }
            else if (Input.GetAxisRaw("Horizontal") == 0)
            {
                playerAnimator.SetBool("isIdling", true);
                playerAnimator.SetBool("isRunning", false);
            }

            if(Input.GetKey(KeyCode.C))
            {
                playerAnimator.SetBool("isCrouching", true);
            }
            else
            {
                playerAnimator.SetBool("isCrouching", false);            
            }
        }

        public void CheckForNearbyNPC()
        {
            var allParticipants = new List<NPC>(FindObjectsOfType<NPC>());
            var target = allParticipants.Find(delegate (NPC p) {
                return string.IsNullOrEmpty(p.talkToNode) == false && // has a conversation node?
                (p.transform.position - this.transform.position)// is in range?
                .magnitude <= interactionRadius;
            });

            if (target != null && Input.GetKeyDown(KeyCode.E))
            {
                if (nodeCounter <= target.nextNodes.Count())
                {
                    dialogueRunner.StartDialogue(target.nextNodes[nodeCounter]);
                    if (nodeCounter == target.nextNodes.Count())
                    {
                        limitReached = true;
                        if (limitReached)
                        {
                            nodeCounter = 0;
                        }
                    }
                    
                }
            }
        }

        /// Draw the range at which we'll start talking to people.
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(playerInteractionPoint.transform.position, interactionRadius);
        }
    }
}