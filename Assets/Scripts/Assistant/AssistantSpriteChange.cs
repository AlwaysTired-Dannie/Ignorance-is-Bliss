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
                actualName = "Face_Neutral";
                //Debug.Log("this script has been called");
                break;
            case Emotion.Happy:
                actualName = "Face_Happy";
                //Debug.Log("switch to Happy");
                break;
            case Emotion.Upset:
                actualName = "Face_Upset";
                //Debug.Log("Switch to Upset");
                break;
            case Emotion.Angry:
                actualName = "Face_Angry";
                break;
            case Emotion.Surprised:
                actualName = "Face_Surprised";
                break;
            case Emotion.Excited:
                actualName = "Face_Excited";
                break;
            case Emotion.Loving:
                actualName = "Face_Loving";
                break;
            case Emotion.Deranged1:
                actualName = "Face_Deranged01";
                break;
            case Emotion.Deranged2:
                actualName = "Face_Deranged02";
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
