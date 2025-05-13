using UnityEngine;

public class AdminScreenEnd : MonoBehaviour, DInterface
{
    [SerializeField] GameObject adminScreen;
    public void OnEndDialogue()
    {
        //opens up admin screen of Assistant
        adminScreen.SetActive(true);
    }

    
}
