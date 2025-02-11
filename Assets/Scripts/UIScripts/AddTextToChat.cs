using UnityEngine;
using TMPro;

public class AddTextToChat : AddText
{
    [SerializeField] GameObject parentObject;
    [SerializeField] GameObject prefabText;
    TextMeshProUGUI textMeshPro;
    [SerializeField] string textMessage;

    //first we grab the textmeshpro component
    private void Start()
    {
        //textMeshPro = prefabText.GetComponent<TextMeshProUGUI>();
        textMeshPro = prefabText.GetComponentInChildren<TextMeshProUGUI>();
    }

    //then we instantiate the object as a child to the parentObject, and set the text as the string
    public override void AddTextChild()
    {
        textMeshPro.text = textMessage;
        Instantiate(prefabText, parentObject.transform);
        
    }
}
