using UnityEngine;

public class ComputerEnd : MonoBehaviour, DInterface
{
    [SerializeField] Transform newTransform;
    [SerializeField] GameObject friendTechInfo, phone, friendTechApp;
    public void OnEndDialogue()
    {
        GameObject assistant = GameObject.FindGameObjectWithTag("Assistant");
        if (assistant != null)
        {
            assistant.transform.position = newTransform.position;
            friendTechInfo.SetActive(true);
            phone.SetActive(true);
            friendTechApp.SetActive(true);
        }
    }

    
}
