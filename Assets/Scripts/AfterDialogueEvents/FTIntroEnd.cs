using UnityEngine;

public class FTIntroEnd : MonoBehaviour, DInterface
{
    [SerializeField] Transform newTransform;
    [SerializeField] GameObject tutorialEnd, phone, friendTechApp, friendTechIcon;
    public void OnEndDialogue()
    {
        GameObject assistant = GameObject.FindGameObjectWithTag("Assistant");
        if (assistant != null)
        {
            assistant.transform.position = newTransform.position;
            tutorialEnd.SetActive(true);
            phone.SetActive(false);
            friendTechApp.SetActive(false);
            friendTechIcon.SetActive(true);
        }
    }

    
}
