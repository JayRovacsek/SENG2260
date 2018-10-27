using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Video;

public class MediaPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public GameObject playButtonInactive;
    public GameObject playButtonHover;
    public GameObject pauseButton;
    private bool Focused { get; set; }

    // Use this for initialization
    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = gameObject.GetComponent<VideoPlayer>();   
        }

        if (audioSource == null)
        {
            audioSource = videoPlayer.GetComponent<AudioSource>();
        }

        SetPlayerStatus(false);
    }

    private void OnMouseOver()
    {
        Focused = true;
    }

    private void OnMouseExit()
    {
        Focused = false;
    }

    public void ToggleMediaPlayerState()
    {
        SetPlayerStatus(!videoPlayer.isPlaying);
    }

    public void SetPlayerStatus(bool play)
    {
        if (play)
        {
            if (videoPlayer != null)
            {
                videoPlayer.Play();
            }
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (videoPlayer != null)
            {
                videoPlayer.Pause();
            }
            if (audioSource != null)
            {
                audioSource.Pause();
            }
        }
    }
}
