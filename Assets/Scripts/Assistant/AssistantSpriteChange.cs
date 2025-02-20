using UnityEngine;

public class AssistantSpriteChange : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public Sprite[] spriteImages;
    public string emotionState;
    string actualName;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        emotionState = "default";
    }
    //REMEMBER TO INVOKE THE VOID SOMEWHERE
    public void SwitchSprite()
    {
        //switch case for emotion changes
        switch (emotionState)
        {
            case "default":
                //spriteRenderer.sprite = spriteImages[0];
                actualName = "AssistantWIPBody";
                break;
            case "upset":
                //spriteRenderer.sprite = spriteImages[1];
                actualName = "upset";
                Debug.Log("switch to upset");
                break;
            case "angry":
                Debug.Log("Switch to angry");
                break;
        }    
        //asign sprite into image
        foreach (Sprite sprite in spriteImages)
        {
            if (sprite.name == actualName)
            {
                spriteRenderer.sprite = sprite;
                break;
            }
        }
    }

    
}
