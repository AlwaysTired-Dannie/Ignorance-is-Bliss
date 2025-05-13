using UnityEngine;

public class AQuestionEnd : MonoBehaviour, DInterface
{
    [SerializeField] GameObject assistantHUD;
    public void OnEndDialogue()
    {
        //enables Assistant Interact HUD, all the questions you can ask her
        assistantHUD.SetActive(true);
    }

   
}
