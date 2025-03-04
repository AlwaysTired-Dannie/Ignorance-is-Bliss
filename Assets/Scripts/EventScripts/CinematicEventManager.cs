using UnityEngine;
using UnityEngine.Playables;
using System;
using System.Collections;
using System.Collections.Generic;

public class CinematicEventManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector boxDropCinematic, boxOpenCinematic, stressIntroCinematic;

    private void Start()
    {
        SubscribeToStoryEvents();
    }

    void SubscribeToStoryEvents()
    {
        FirstScrollEvent.OnScrolledToBottom += PlayBoxDropCinematic;
        IFTBox.onOpenedBox += PlayBoxOpenCinematic;
        AIntroEnd.onStressIntro += PlayStressIntroCinematic;
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

    private void PlayStressIntroCinematic()
    {
        stressIntroCinematic.Play();
        AIntroEnd.onStressIntro -= PlayStressIntroCinematic;
    }
}
