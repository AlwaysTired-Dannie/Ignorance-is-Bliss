using UnityEngine;

public class IComputer : MonoBehaviour, IInteractable
{
    private bool firstClick = true;
    [SerializeField] public GameObject firstComputerClick;
    [SerializeField] public GameObject computer;
    public void OnClickAction()
    {
        if (firstClick) { 
            firstComputerClick.SetActive(true);
            Debug.Log("open cat video");
            firstClick = false;
        } else { 
            computer.SetActive(true); }
    }

    public void CloseComputer()
    {
        GameManager.instance.StopStressChange();
        computer.SetActive(false);
    }

    
}
