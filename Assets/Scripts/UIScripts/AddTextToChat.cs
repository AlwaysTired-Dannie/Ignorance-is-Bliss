using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NUnit.Framework;

[System.Serializable]
public class TextMessage
{
    [SerializeField] string textMessage;
    [SerializeField] string date;
    [SerializeField] GameObject parentObject;
    [SerializeField] GameObject prefabText;
    
    public void InstantiateText()
    {
        //First, check if the prefab and parentObject are assigned
        if (prefabText == null || parentObject == null )
        {
            Debug.LogError("Prefab or parent object not assigned");
            return;
        }

        //Instantiate prefab
        GameObject newTextObject = GameObject.Instantiate(prefabText, parentObject.transform);

        //Get TMP components
        TextMeshProUGUI textBodyTMP = newTextObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI textDateTMP = newTextObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        // Check if the TextMeshPro components are found
        if (textBodyTMP == null || textDateTMP == null)
        {
            Debug.LogError("TextMeshPro components not found in the prefab!");
            return;
        }

        // Set the text
        textBodyTMP.text = textMessage;
        textDateTMP.text = date;
    }
}

public class AddTextToChat : MonoBehaviour
{
    public List<TextMessage> textMessages = new List<TextMessage>();
    //[SerializeField] GameObject parentObject;
    public static Action notifSound;
    
    public void AddTextChild()
    {
        notifSound.Invoke();
        /*if (parentObject == null)
        {
            Debug.LogError("Parentobject not assigned!");
            return;
        }*/

        foreach (var message in textMessages)
        {
            message.InstantiateText();
        }

    }
}
