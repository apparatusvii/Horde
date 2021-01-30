using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Yarn.Unity
{
    public class OnStart : MonoBehaviour
    {
        public float startDelayTime;
        public float nextLineDelayTime;

        [Header("Character Script")]
        public YarnProgram scriptToLoad;
        public string talkToNode = "";

        [Header("Character Parts")]
        public string[] characterNames;
        public Color[] characterColors;
        public TMP_FontAsset[] fontAssets;
        public Image textBox;
        public TextMeshProUGUI textComponent;

        [Header("References")]
        public DialogueRunner runner;
        public DialogueUI_Two dialogueUI_Two;

        void Start()
        {
            StartCoroutine(MoveToNextLine());
        }
        IEnumerator MoveToNextLine()
        {
            yield return new WaitForSeconds(startDelayTime);
            RunDialogue();
            while (true)
            {
                yield return new WaitForSeconds(nextLineDelayTime);
                MarkLine();
            }
        }

        void RunDialogue()
        {
             if (scriptToLoad != null)
            {
                runner.Add(scriptToLoad);
            }
            runner.StartDialogue(talkToNode);
        }

        void MarkLine()
        {
            dialogueUI_Two.MarkLineComplete();
        }

        public string LineReplace(string text)
        {
            foreach (var character in characterNames)
            {
                int index = Array.IndexOf(characterNames, character);
                if (text.StartsWith(characterNames[index]))
                {
                    textBox.color = characterColors[index];
                    textComponent.color = characterColors[index];
                    textComponent.font = fontAssets[index];
                    text = text.Replace(characterNames[index], "").Trim();
                    return text;
                }
            }
            return "";
        }
    }
}

