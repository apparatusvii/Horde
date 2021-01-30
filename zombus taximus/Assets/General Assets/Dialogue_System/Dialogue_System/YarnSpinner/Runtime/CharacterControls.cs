using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace Yarn.Unity.Example
{
    public class ThirdPersonController : MonoBehaviour
    {
        [Header("Player Movement")]
        public CharacterController playerController;
        public float moveSpeed;
        float angle;
        Quaternion characterRotation;
        Vector3 move = Vector3.zero;

        [Header("Interaction")]
        public Transform playerInteractionPoint;
        public float interactionRadius;
        private int nodeCounter = 0;
        private bool limitReached;
       
        [Header("References")]
        public Animator playerAnimator;

        private void Update()
        {
            MovePlayer();
            RotatePlayer();
            Animations();
            LocateDialogue();
        }
        void MovePlayer()
        {
            var speed = moveSpeed * Time.deltaTime;
            move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            playerController.Move(move.normalized * speed);
        }

        void RotatePlayer()
        {
            angle = Mathf.Atan2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Mathf.Rad2Deg;
            transform.GetChild(0).rotation = characterRotation;
            characterRotation = Quaternion.Euler(new Vector3(0, angle, 0));
            if (characterRotation.y == 0)
            {
                characterRotation = transform.GetChild(0).rotation;
            }
            
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                characterRotation.y = 0f;
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
        }
        void LocateDialogue()
        {
            // Remove all player control when we're in dialogue
            if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
            {
                return;
            }
            // Detect if we want to start a conversation
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckForNearbyNPC();
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
            if (target != null)
            {
                if (nodeCounter <= target.nextNodes.Count())
                {
                    FindObjectOfType<DialogueRunner>().StartDialogue(target.nextNodes[nodeCounter]);
                    nodeCounter++;
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
            // Need to draw at position zero because we set position in the line above
            //Gizmos.DrawWireSphere(player.transform.position, interactionRadius);
            Vector3 direction = playerInteractionPoint.transform.TransformDirection(Vector3.forward) * interactionRadius;
            Gizmos.DrawRay(playerInteractionPoint.transform.position, direction);
        }

    }
}