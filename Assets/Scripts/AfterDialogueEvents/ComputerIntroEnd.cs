using UnityEngine;

public class ComputerIntroEnd : MonoBehaviour, DInterface
{
    [SerializeField] GameObject computerInteractable, computerTutorial;
    public void OnEndDialogue()
    {
        computerInteractable.SetActive(true);
        computerTutorial.SetActive(true);
    }

    
}
