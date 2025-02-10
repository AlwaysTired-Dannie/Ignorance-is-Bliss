using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FirstLoadEvent : MonoBehaviour
{
    [Header("Events")]
    UnityEvent onLoadEvent;
    UnityEvent onPressEnter = new UnityEvent();

    [Header("GameObjects")]
    [SerializeField] AudioSource phoneNotifSource;
    [SerializeField] GameObject phoneTutorial;
    
    void Start()
    {
        if (onLoadEvent == null)
        {
            onLoadEvent = new UnityEvent();
        }

        onLoadEvent.AddListener(OpenPhoneEvent);
        onPressEnter.AddListener(PressEnter);
        StartCoroutine(Countdown());

    }

    //waits for 5 seconds before invoking event
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5f);
        onLoadEvent.Invoke();
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            onPressEnter.Invoke();
        }
    }

    //Event that sounds phone and control tutorial
    public void OpenPhoneEvent()
    {
        phoneNotifSource.PlayDelayed(1);
        phoneTutorial.SetActive(true);
        //Debug.Log("Phone notif");
    }

    public void PressEnter()
    {
        phoneTutorial.SetActive(false);
        phoneNotifSource.Stop();
        onPressEnter.RemoveAllListeners();
    }
}
