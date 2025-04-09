using UnityEngine;

public class AssistantSpriteChange : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public Sprite[] spriteImages;
    string actualName;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TypewriterMessage.onEmotionChange += SwitchSprite;
    }
    //REMEMBER TO INVOKE THE VOID SOMEWHERE
    public void SwitchSprite()
    {
        //switch case for emotion changes
        switch (TypewriterMessage.currentemotion)
        {
            case Emotion.Normal:
                //spriteRenderer.sprite = spriteImages[0];
                actualName = "Face_Neutral";
                Debug.Log("this script has been called");
                break;
            case Emotion.Happy:
                //spriteRenderer.sprite = spriteImages[1];
                actualName = "upset";
                Debug.Log("switch to Happy");
                break;
            case Emotion.Upset:
                Debug.Log("Switch to Upset");
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
