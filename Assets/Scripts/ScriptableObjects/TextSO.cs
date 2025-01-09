using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextSO", menuName = "Scriptable Objects/TextSO")]
public class TextSO : ScriptableObject
{
    public List<TypewriterMessage> Messages = new List<TypewriterMessage>();
}
