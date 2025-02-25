using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTextAssistant : MonoBehaviour
{
    public static TextSO scriptableObject;
    
    void Start()
    {
        ScrollingText.Add(scriptableObject);
        //activate the type writer
        ScrollingText.Activate();
    }
    
}
