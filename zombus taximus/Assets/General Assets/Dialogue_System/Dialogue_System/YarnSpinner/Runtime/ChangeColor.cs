using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;
public class ChangeColor : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    [YarnCommand("Red")]
    public void ChangeToRed()
    {
        text.color = new Color(255, 0, 0);
    }

    [YarnCommand("green")]
    public void ChangeToGreen()
    {
        text.color = new Color(0, 255, 0);
    }

    //[YarnCommand("Blue")]
    //public void ChangeToBlue()
    //{
    //    text.color = new Color(0, 0, 255);
    //}

    //[YarnCommand("White")]
    //public void ChangeToWhite()
    //{
    //    text.faceColor = new Color(255, 255, 255);
    //}
}
