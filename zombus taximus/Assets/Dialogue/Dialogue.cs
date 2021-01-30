using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] dialogueText;
    private int index;
    public float typingSpeed;

    void Start()
    {
        //StartCoroutine(Type());
    }

    public IEnumerator Type()
    {
        foreach(char letter in dialogueText[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
