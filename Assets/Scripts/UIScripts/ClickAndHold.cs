using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickAndHold : MonoBehaviour
{
    public float holdDuration = 3f;
    public Image fillCircle;

    private float holdTimer = 0f;
    private bool isHolding = false;

    private void Awake()
    {
        StartCoroutine(HoldTimer());
    }

    IEnumerator HoldTimer()
    {
        if (isHolding)
        {
            holdTimer += Time.deltaTime;
            fillCircle.fillAmount = holdTimer / holdDuration;
            if (holdTimer > holdDuration)
            {
                //do something here
            }
        }
        yield break;
    }
}
