using UnityEngine;

public class IAssistant : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("Interacted with assistant");
    }

    
}
