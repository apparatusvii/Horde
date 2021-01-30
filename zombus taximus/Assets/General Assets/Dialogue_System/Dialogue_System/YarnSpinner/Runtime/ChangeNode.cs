using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace Yarn.Unity
{
    public class ChangeNode : MonoBehaviour
    {
        public NPC npcScript;
        public YarnProgram[] nextNodes;
        public string[] talkToNodes;

        [YarnCommand("NextNode")]
        public void LoadNodes()
        {
            npcScript.scriptToLoad = nextNodes[0];
            npcScript.talkToNode = talkToNodes[0];
        }
    }
}

