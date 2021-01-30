using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CommandManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public NPC nPC;
    public ThirdPersonController thirdPersonController;

    void Awake()
    {
        dialogueRunner.AddCommandHandler("nextNode", NextNode);
        dialogueRunner.AddCommandHandler("clearCounter", ClearCounter);
    }

    private void NextNode(string[] parameters)
    {
        int nodeNumber = int.Parse(parameters[0]);
        thirdPersonController.nodeCounter = nodeNumber;
    }
    private void ClearCounter(string[] parameters)
    {
        thirdPersonController.nodeCounter = 0;
    }
}
