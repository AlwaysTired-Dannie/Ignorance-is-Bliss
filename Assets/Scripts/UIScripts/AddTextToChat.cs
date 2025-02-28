using UnityEngine;
using TMPro;

public class AddTextToChat : AddText
{
    [SerializeField] GameObject parentObject;
    [SerializeField] GameObject prefabText;
    TextMeshProUGUI textBodyTMP;
    TextMeshProUGUI textDateTMP;
    [SerializeField] string textMessage;
    [SerializeField] string date;

    //first we grab the textmeshpro component
    private void Start()
    {
        //textMeshPro = prefabText.GetComponent<TextMeshProUGUI>();
        GameObject textBody  = prefabText.transform.GetChild(1).gameObject;
        textBodyTMP = textBody.GetComponent<TextMeshProUGUI>();
        GameObject textDate = prefabText.transform.GetChild(0).gameObject;
        textDateTMP = textDate.GetComponent<TextMeshProUGUI>();
    }

    //then we instantiate the object as a child to the parentObject, and set the text as the string
    public override void AddTextChild()
    {
        textBodyTMP.text = textMessage;
        textDateTMP.text = date;
        Instantiate(prefabText, parentObject.transform);
        
    }
}
