using System;
using UnityEngine;

public class TutorialEnd : MonoBehaviour, DInterface
{
    [SerializeField] Transform newTransform;
    public static Action onTutorialEnd;
    public void OnEndDialogue()
    {
        GameObject assistant = GameObject.FindGameObjectWithTag("Assistant");
        if (assistant != null)
        {
            assistant.transform.position = newTransform.position;
            onTutorialEnd.Invoke();
            assistant.layer = 6;
        }
    }

}
