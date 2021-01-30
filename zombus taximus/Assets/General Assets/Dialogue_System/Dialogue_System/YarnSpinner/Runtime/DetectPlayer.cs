using UnityEngine;
using TMPro;

public class DetectPlayer : Interactable
{
    Outline outline;

    [Header("Interact UI")]
    public GameObject textObject;
    public TextMeshProUGUI text;
    public string interactionType;

    public Transform uiParent;

    void Start()
    {
        outline = GetComponent<Outline>();
    }

    void Update()
    {
        InRange();
    }
    
    public void InRange()
    {
        inRange = Physics.CheckSphere(this.centerPoint.position, interactionRadius, playerLayer);
        if(inRange)
        {
            string characterName = gameObject.name;
            string talkTo = interactionType + " " + characterName;
            text.text = talkTo;
            textObject.transform.position = uiParent.position;
            textObject.SetActive(true);
            outline.enabled = true;
        }
        else 
        {
            textObject.SetActive(false);
            outline.enabled = false;
        }
    }
}
