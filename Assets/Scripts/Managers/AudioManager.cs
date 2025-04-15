using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioSource phoneNotif;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddTextToChat.notifSound += PhoneSound;
    }

    public void PhoneSound()
    {
        phoneNotif.Play();
    }
}
