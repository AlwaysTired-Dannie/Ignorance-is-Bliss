using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class  TypewriterMessage 
{
    private float timer = 0;
    private int charIndex;
    public float typeSpeed = 0.05f;
    [SerializeField]
    public string currentText = null;
    private string displayText = null;

    private Action onActionCallback = null;
    public TypewriterMessage(string msg, Action callback = null)
    {
        onActionCallback = callback;
        currentText = msg;
    }

    public void Callback()
    {
        if (onActionCallback != null) onActionCallback();
    }

    public string GetFullMsgAndCallback()
    {
        if (onActionCallback != null) onActionCallback();
        return currentText;
    }

    public string GetFullMsg()
    {
        return currentText;
    }

    public string GetMsg()
    {
        return displayText;
    }

    public void Update()
    {
        if (string.IsNullOrEmpty(currentText))
            return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //keep revealing more of the message
            timer += typeSpeed;
            charIndex++;

            //assign the message to the typewriter
            displayText = currentText.Substring(0, charIndex);
            displayText += "<color=#00000000>" + currentText.Substring(charIndex) + "</color>";

            //if we have reached the end of the sentence, stop typing
            if (charIndex >= currentText.Length)
            {
                Callback();
                currentText = null;
            }
        }
    }

    public bool IsActive()
    {
        if (string.IsNullOrEmpty(currentText))
            return false;

        return charIndex < currentText.Length;
    }
}

public class ScrollingText : MonoBehaviour
{
    public TextMeshProUGUI tmpComponent;
    //public Text Textcomponent ;

    private static ScrollingText instance;
    private List<TypewriterMessage> messages = new List<TypewriterMessage>();

    private TypewriterMessage currentText = null;
    private int msgIndex = 0;

    public static void Add(string msg, Action callback = null)
    {
        TypewriterMessage typeMsg = new TypewriterMessage(msg, callback);
        instance.messages.Add(typeMsg);
    }

    public static void Add(TextSO scrObj)
    {
        for(int i = 0; i < scrObj.Messages.Count; i++)
        {
            TypewriterMessage typeMsg = new TypewriterMessage(scrObj.Messages[i].GetFullMsg());
            instance.messages.Add(typeMsg);
        }
    }

    public static void Activate()
    {
        instance.currentText = instance.messages[0];
    }

    private void Awake()
    {
        instance = this;
        
    }
    private void Update()
    {
        if (messages.Count > 0 && currentText != null)
        {
            currentText.Update();
            tmpComponent.text = currentText.GetMsg();
        }
    }

    public void WriteNextMessageInQueue()
    {
        //if active, show the entire string
        if (currentText != null && currentText.IsActive())
        {
            tmpComponent.text = currentText.GetFullMsgAndCallback();
            currentText = null;
            return;
        }

        msgIndex++;

        if (msgIndex >= messages.Count)
        {
            currentText = null;
            tmpComponent.text = "";
            Debug.Log("End of queue");
            gameObject.SetActive(false);
            return;
        }
        currentText = messages[msgIndex];
    }






}
