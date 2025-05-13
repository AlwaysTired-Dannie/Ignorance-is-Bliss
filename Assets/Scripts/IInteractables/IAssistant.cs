using UnityEngine;

public class IAssistant : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject interactDial;
    public void OnClickAction()
    {
        Debug.Log("Interacted with assistant");
        interactDial.SetActive(true);
    }

    
}
