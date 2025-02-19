using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FirstScrollEvent : MonoBehaviour
{
    [SerializeField] ScrollRect scrollRect;
    public static Action OnScrolledToBottom;


    private void Start()
    {
        StartCoroutine(CheckIfEndOfScroll());
    }

    //checks if player has scrolled to bottom of FriendTech message, then stops coroutine and invokes event
    IEnumerator CheckIfEndOfScroll()
    {
        if (scrollRect.verticalNormalizedPosition <= 0.05f)
        {
            OnScrolledToBottom.Invoke();
            StopCoroutine(CheckIfEndOfScroll());
        }
        yield return null;
    }
}
