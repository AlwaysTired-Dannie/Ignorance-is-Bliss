using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static EmotionSO;

[CreateAssetMenu(fileName = "EmotionSO", menuName = "Scriptable Objects/Emotion SO")]

public class EmotionSO : ScriptableObject
{
    public enum Emotion
    {
        Normal,
        Upset,
        Angry
    }

    public Emotion emotion;

    public void Start()
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
   
}
