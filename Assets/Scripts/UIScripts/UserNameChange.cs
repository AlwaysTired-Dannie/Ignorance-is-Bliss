using UnityEngine;
using TMPro;

public class UserNameChange : MonoBehaviour
{
    string chatName;
    string userName;
    [SerializeField] TextMeshProUGUI textMeshPro;

    
    void Start()
    {
        chatName = this.gameObject.name;
    }

    public void SetName()
    {
        userName = chatName;
        textMeshPro.text = userName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
