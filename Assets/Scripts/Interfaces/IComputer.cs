using UnityEngine;

public class IComputer : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("Clicked on the computer");
    }

    private void OnEnable()
    {
        InteractableManager.AddToInteractablesEvent.Invoke(transform);
    }

    private void OnDisable()
    {
        InteractableManager.RemoveFromInteractablesEvent.Invoke(transform);
    }
}
