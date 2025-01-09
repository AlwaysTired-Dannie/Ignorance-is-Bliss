using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    [SerializeField] private GameObject phoneMenu;
    [SerializeField] private GameObject phMainMenuCanvas;
    [SerializeField] private GameObject phMessagesCanvas;

    private bool isOpen;

    private void Start()
    {
        phoneMenu.SetActive(false);
        phMainMenuCanvas.SetActive(false);
        phMessagesCanvas.SetActive(false);
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
        phMessagesCanvas.SetActive(false);
    }

    private void CloseAllPhones()
    {
        phoneMenu.SetActive(false);
        phMainMenuCanvas.SetActive(false);
        phMessagesCanvas.SetActive(false);
    }

    public void OpenMessagesMenu()
    {

    }
    #endregion
}
