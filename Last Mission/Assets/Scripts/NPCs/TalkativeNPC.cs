using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkativeNPC : NPC
{
    [SerializeField]
    private string messageToSay = string.Empty;

    [SerializeField]
    private TextMeshProUGUI messageText;

    [SerializeField]
    private GameObject messageBox;

    private float typeTextSpeed = 0.05f;

    public override void DisableInteraction()
    {
        messageBox.SetActive(false);
        messageText.text = string.Empty;
    }
     
    public override void InteractWithPlayer()
    {
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        messageBox.SetActive(true);

        foreach (var letter in messageToSay)
        {
            messageText.text += letter;
            yield return new WaitForSeconds(typeTextSpeed);
        }
    }
}
