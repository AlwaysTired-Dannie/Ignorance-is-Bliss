using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
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
    [SerializeField] public Emotion emotion;
    public TypewriterMessage(string msg, Action callback = null)
    {
        onActionCallback = callback;
        currentText = msg;
    }

    public void Callback()
    {
        if (onActionCallback != null) onActionCallback();
    }

    public void ChangeEmotion()
    {
        switch (emotion)
        {
            case Emotion.Normal:
                Debug.Log("Emotion is normal");
                break;
            case Emotion.Upset:
                Debug.Log("Emotion is upset");
                break;
            case Emotion.Angry:
                Debug.Log("Emotion is angry");
                break;
        }
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
            displayText += "<color=#00000000>" + currentText.Substring(charIndex) + "</color>"; //this is simply a preference so the text doesn't squiggle
            

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
public enum Emotion
{
    Normal,
    Upset,
    Angry
}

public class ScrollingText : MonoBehaviour
{
    public TextMeshProUGUI tmpComponent;

    private static ScrollingText instance;
    private List<TypewriterMessage> messages = new List<TypewriterMessage>();

    private TypewriterMessage currentText = null;
    private int msgIndex = 0;

    public static Action closePhone;

    //this is for string messages in a script
    public static void Add(string msg, Action callback = null)
    {
        TypewriterMessage typeMsg = new TypewriterMessage(msg, callback);
        instance.messages.Add(typeMsg);
    }

    //adds the messages from the scriptable object list
    public static void Add(TextSO scrObj)
    {
        for (int i = 0; i < scrObj.Messages.Count; i++)
        {
            //Get emotion from the scriptable object
            Emotion messageEmotion = scrObj.Messages[i].emotion;
            TypewriterMessage typeMsg = new TypewriterMessage(scrObj.Messages[i].GetFullMsg(), null)
            {
                //typeSpeed = scrObj.Messages[i].typeSpeed,
                emotion = messageEmotion
            };
            instance.messages.Add(typeMsg);
        }
        
    }

    public static void Activate()
    {
        //start of messages
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
        currentText.ChangeEmotion();
        //if active, show the entire string
        if (currentText != null && currentText.IsActive())
        {
            tmpComponent.text = currentText.GetFullMsgAndCallback();
            currentText = null;
            return;
        }
        //next message
        msgIndex++;

        if (msgIndex >= messages.Count)
        {
            currentText = null;
            tmpComponent.text = "";
            EndOfMessages();
            gameObject.SetActive(false);
            return;
        }
        currentText = messages[msgIndex];
    }

    public void EndOfMessages()
    {
        DInterface dInterface = this.gameObject.GetComponent<DInterface>();
        if (dInterface != null)
        {
            dInterface.OnEndDialogue();
        }
        
        Debug.Log("End of queue");
    }

}
