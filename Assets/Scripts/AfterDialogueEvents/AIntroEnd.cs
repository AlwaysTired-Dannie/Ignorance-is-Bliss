using System;
using UnityEngine;

public class AIntroEnd : MonoBehaviour, DInterface
{
    public static Action onStressIntro;
    public void OnEndDialogue()
    {
        onStressIntro.Invoke();
    }

    
}
