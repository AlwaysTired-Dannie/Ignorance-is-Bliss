using NUnit.Framework;
using UnityEngine;
using UnityEngine.Video;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Video
{
    [SerializeField] public bool stressful;
    [SerializeField] public VideoClip clip;

}
public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField] public List<Video> videoList;
    private VideoPlayer player;
    //private int videoIndex = 0;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        SwitchVideo();
    }

    private void OnEnable()
    {
        //SwitchVideo();
    }

    public void SwitchVideo()
    {
        //first stops the stress change from previous video
        StopVideo();
        // select a random video from a list
        int randomIndex = UnityEngine.Random.Range(0, videoList.Count);
        Video randomVideo = videoList[randomIndex];

        //set the player's clip to the selected video's clip
        player.clip = randomVideo.clip;

        if (randomVideo.stressful)
        {
            GameManager.instance.StartStressChange(5, 5); // Increase stress by 5 every 5 seconds
        }
        else
        {
            GameManager.instance.StartStressChange(-5, 5); // Decrease stress by 5 every 5 seconds
        }

    }

    public void StopVideo()
    {
        GameManager.instance.StopStressChange(); // Stop stress changes when the video ends
    }
}
