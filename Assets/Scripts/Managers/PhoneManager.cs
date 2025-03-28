using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    [SerializeField] private GameObject phoneMenu, phMainMenuCanvas, phBackground, FTCanvas;

    public static bool isOpen;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            foreach(Transform child2 in child) {
                child2.gameObject.SetActive(false);
            }
            child.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (InputManager.instance.PhoneOpenCloseInput)
        {
            if (!isOpen)
            {
                OpenPhone();
            }
            else
            {
                ClosePhone();
            }
        }
    }

    #region Open/Close Phone Functions

    public void OpenPhone()
    {
        isOpen = true;
        OpenPhoneMenu();
    }

    public void ClosePhone()
    {
        isOpen = false;
        CloseAllPhones();
    }

    #endregion

    #region Canvas Activations

    private void OpenPhoneMenu()
    {
        phoneMenu.SetActive(true);
        phMainMenuCanvas.SetActive(true);
        phBackground.SetActive(true);
        FTCanvas.SetActive(false);
    }

    private void CloseAllPhones()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform child2 in child)
            {
                child2.gameObject.SetActive(false);
            }
            child.gameObject.SetActive(false);
        }
        FTCanvas.SetActive(false);
    }

    public void OpenMessagesMenu()
    {

    }
    #endregion
}
