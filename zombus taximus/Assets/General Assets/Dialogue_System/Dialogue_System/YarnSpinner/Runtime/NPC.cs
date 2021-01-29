/*

The MIT License (MIT)

Copyright (c) 2015-2017 Secret Lab Pty. Ltd. and Yarn Spinner contributors.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Yarn.Unity
{
    /// attached to the non-player characters, and stores the name of the Yarn
    /// node that should be run when you talk to them.
    public class NPC : MonoBehaviour
    {
        [Header("Dialogue Container")]
        public GameObject dialogueContainer;
        
        [Header("Character Script")]
        public YarnProgram scriptToLoad;
        public string talkToNode = "";
        public string[] nextNodes;

        [Header("Character Parts")]
        public string[] characterNames;
        public Color[] characterColors;
        public TMP_FontAsset[] fontAssets;
        public Transform[] dialogueContainerParent;

        [Header("References")]
        public TextMeshProUGUI textComponent;


        void Start()
        {
            DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            if (scriptToLoad != null)
            {
                dialogueRunner.Add(scriptToLoad);
            }
        }

        public void LineReplace(string text)
        {
            foreach (var character in characterNames)
                {
                    int index = Array.IndexOf(characterNames, character);
                        if (text.StartsWith(characterNames[index]))
                        {
                            dialogueContainer.transform.position = dialogueContainerParent[index].position;
                            textComponent.color = characterColors[index];
                            textComponent.font = fontAssets[index];
                            text = text.Replace(characterNames[index], "").Trim();
                            return;
                }
        }

            Debug.Log("Can't find a character named: " + text);
        }
    }
}
