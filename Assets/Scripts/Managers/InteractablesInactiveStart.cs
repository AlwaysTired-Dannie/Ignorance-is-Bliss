using UnityEngine;

public class InteractablesInactiveStart : MonoBehaviour
{
    
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.layer == 6)
            {
               child.gameObject.SetActive(false);
                 
            }
        }
    }

    
}
