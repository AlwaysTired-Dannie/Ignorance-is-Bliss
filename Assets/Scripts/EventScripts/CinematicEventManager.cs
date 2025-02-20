using UnityEngine;
using UnityEngine.Playables;
using System;
using System.Collections;
using System.Collections.Generic;

public class CinematicEventManager : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector boxDropCinematic;
    private PlayableDirector boxOpenCinematic;

    private void Start()
    {
        SubscribeToStoryEvents();
    }

    void SubscribeToStoryEvents()
    {
        FirstScrollEvent.OnScrolledToBottom += PlayBoxDropCinematic;
        IFTBox.onOpenedBox += PlayBoxOpenCinematic;
    }

    private void PlayBoxDropCinematic()
    {
        boxDropCinematic.Play();
        FirstScrollEvent.OnScrolledToBottom -= PlayBoxDropCinematic;
    }

    private void PlayBoxOpenCinematic()
    {
        boxOpenCinematic.Play();
        IFTBox.onOpenedBox -= PlayBoxOpenCinematic;
    }
}
