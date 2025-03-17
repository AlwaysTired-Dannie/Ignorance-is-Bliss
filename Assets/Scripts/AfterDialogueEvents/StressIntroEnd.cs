using UnityEngine;

public class StressIntroEnd : MonoBehaviour, DInterface
{
    [SerializeField] Transform newTransform;
    [SerializeField] GameObject computerDialogue;
    public void OnEndDialogue()
    {
        //finds the assistant, then assigns her position to the new transform next to the computer
        GameObject assistant = GameObject.FindGameObjectWithTag("Assistant");
        if (assistant != null) { 
            assistant.transform.position = newTransform.position;
            computerDialogue.SetActive(true);
        }
    }

}
