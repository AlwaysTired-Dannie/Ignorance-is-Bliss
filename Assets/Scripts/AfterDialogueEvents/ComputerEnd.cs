using UnityEngine;

public class ComputerEnd : MonoBehaviour, DInterface
{
    [SerializeField] Transform newTransform;
    [SerializeField] GameObject friendTechInfo, phone, phoneBackground, friendTechApp;
    public void OnEndDialogue()
    {
        GameObject assistant = GameObject.FindGameObjectWithTag("Assistant");
        if (assistant != null)
        {
            assistant.transform.position = newTransform.position;
            friendTechInfo.SetActive(true);
            phone.SetActive(true);
            phoneBackground.SetActive(true);
            friendTechApp.SetActive(true);
        }
    }

    
}
