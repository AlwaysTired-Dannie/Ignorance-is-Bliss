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

    public void SwitchSprite()
    {
        
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

    private void Update()
    {
        SwitchSprite();
        if (Input.GetMouseButton(0))
        {
            emotionState = "upset";
        }
        if (Input.GetMouseButton(1))
        {
            emotionState = "default";
        }
        if (Input.GetMouseButton(2))
        {
            emotionState = "angry";
        }
    }
}
