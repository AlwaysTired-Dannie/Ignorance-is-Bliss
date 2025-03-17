using UnityEngine;

public class TutorialEnd : MonoBehaviour, DInterface
{
    [SerializeField] Transform newTransform;
    public void OnEndDialogue()
    {
        GameObject assistant = GameObject.FindGameObjectWithTag("Assistant");
        if (assistant != null)
        {
            assistant.transform.position = newTransform.position;
        }
    }

}
