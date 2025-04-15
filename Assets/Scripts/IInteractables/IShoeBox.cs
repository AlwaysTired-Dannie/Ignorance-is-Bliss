using UnityEngine;

public class IShoeBox : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("Interacted with shoe box");
    }

    
}
