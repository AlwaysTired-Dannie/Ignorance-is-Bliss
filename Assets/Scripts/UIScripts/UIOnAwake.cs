using UnityEngine;

public class UIOnAwake : MonoBehaviour
{
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
