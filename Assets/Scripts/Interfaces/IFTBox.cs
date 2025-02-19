using System;
using UnityEngine;

public class IFTBox : MonoBehaviour, IInteractable
{
    public static Action OnOpenBox;
    public void OnClickAction()
    {
        Debug.Log("interacted with FriendTech Box");
    }

    
}
