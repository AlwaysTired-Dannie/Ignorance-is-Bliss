using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IFTBox : MonoBehaviour, IInteractable
{
    public static Action OnOpenBox;
    public float holdDuration = 6f;
    public Image fillCircle;
    [SerializeField] AudioSource fillCircleSound;

    private float holdTimer = 0f;
    private bool isHolding = false;

    public static Action onOpenedBox;
    public void OnClickAction()
    {
        StartCoroutine(FillCircle());
        //StartCoroutine(HoldTimer());
    }

    IEnumerator FillCircle()
    {
        while (true)
        {
            isHolding = true;
            if (isHolding && Input.GetMouseButton(0))
            {
                holdTimer += Time.deltaTime;
                fillCircle.fillAmount = holdTimer / holdDuration;
                if (!fillCircleSound.isPlaying)
                {
                    PlayMusic();
                }
                
            }
            
            if (holdTimer >= holdDuration)
            {
                AssistantTime();
                
                yield break;
            }
            yield return null;
        } 
        
    }

    public void PlayMusic()
    {
        fillCircleSound.Play();
    }

    public void AssistantTime()
    {
        fillCircleSound.Stop();
        onOpenedBox.Invoke();
    }
    

}
