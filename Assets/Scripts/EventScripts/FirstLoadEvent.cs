using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FirstLoadEvent : MonoBehaviour
{
    [Header("Events")]
    public static Action onLoadEvent;
    public static Action onPressEnter;
    //UnityEvent onLoadEvent;
    //UnityEvent onPressEnter = new UnityEvent();

    [Header("GameObjects")]
    [SerializeField] AudioSource phoneNotifSource;
    [SerializeField] GameObject phoneTutorial;
    
    void Start()
    {
        /*if (onLoadEvent == null)
        {
            onLoadEvent = new UnityEvent();
        }*/
        onLoadEvent += OpenPhoneEvent;
        onPressEnter += PressEnter;
        //onLoadEvent.AddListener(OpenPhoneEvent);

        //onPressEnter.AddListener(PressEnter);
        StartCoroutine(Countdown());

    }

    //waits for 5 seconds before invoking event
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5f);
        onLoadEvent.Invoke();
        StopCoroutine(Countdown());
        
    }

    //checks if enter is pressed
    void Update()
    {
        if (Input.GetButtonDown("Submit") && phoneTutorial.activeSelf)
        {
            onPressEnter.Invoke();
        }
    }

    //Event that sounds phone and control tutorial UI
    public void OpenPhoneEvent()
    {
        phoneNotifSource.PlayDelayed(1);
        phoneTutorial.SetActive(true);
    }

    //if enter was pressed, deactivate tutorial UI, stops notifcation sound, and unsubscribes event
    public void PressEnter()
    {
        phoneTutorial.SetActive(false);
        phoneNotifSource.Stop();
        onPressEnter -= PressEnter;
        onLoadEvent -= OpenPhoneEvent;
    }
}
