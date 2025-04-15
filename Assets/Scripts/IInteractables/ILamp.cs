using UnityEngine;

public class ILamp : MonoBehaviour, IInteractable
{
    [SerializeField] Light lampLight;
    bool isOn = true;

    private void Start()
    {
        //lampLight = GetComponent<Light>();
    }
    public void OnClickAction()
    {
        switch (isOn)
        {
            case true:
                lampLight.enabled = false;
                isOn = false;
                break;
            case false:
                lampLight.enabled = true;
                isOn = true; break;
        }
        
    }

    
}
