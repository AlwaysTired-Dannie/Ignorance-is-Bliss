using UnityEngine;

public class IPot : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("clicked on pot");
    }

    
}
