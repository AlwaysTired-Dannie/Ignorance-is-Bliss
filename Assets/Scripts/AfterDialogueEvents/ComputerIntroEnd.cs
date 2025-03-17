using UnityEngine;

public class ComputerIntroEnd : MonoBehaviour, DInterface
{
    [SerializeField] GameObject computerInteractable;
    public void OnEndDialogue()
    {
        computerInteractable.SetActive(true);
    }

    
}
