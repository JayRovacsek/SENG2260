﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Screen : MonoBehaviour {

    private GameObject VideoPlayer { get; set; }
    private GameObject AudioPlayer { get; set; }
    public GameObject Menu { get; set; }
    private GameObject Player { get; set; }
    private bool IsInProximity { get; set; }
    private bool IsVisible { get; set; }
    private VideoPlayer Video { get; set; }
    private AudioSource Audio { get; set; }

	// Use this for initialization
	void Start () {
        VideoPlayer = GameObject.FindWithTag("Video");
        AudioPlayer = GameObject.FindWithTag("Audio");
        Menu = GameObject.FindWithTag("Menu");
        Player = GameObject.FindWithTag("Player");
        Video = VideoPlayer.GetComponent<VideoPlayer>();
        Audio = AudioPlayer.GetComponent<AudioSource>();
        Video.isLooping = true;
        Audio.loop = true;
    }

    // Update is called once per frame
    void Update () {
        IsVisible = CheckVisibility();
        if (IsVisible)
        {
            UpdateVideoStatus();
        }
        else
        {
            PausePlaying();
        }
    }

    private void UpdateVideoStatus()
    {
        IsInProximity = CheckProximity(Player.transform);
        if (IsInProximity)
        {
            if (!Video.isPlaying)
            {
                StartPlaying();
            }
        }
        else
        {
            if (Video.isPlaying)
            {
                PausePlaying();
            }
        }
    }

    private void StartPlaying()
    {
        Video.Play();
        Audio.Play();
    }

    private void PausePlaying()
    {
        Video.Pause();
        Audio.Pause();
    }

    private bool CheckProximity(Transform playerTransform)
    {
        var result = (Vector3.Distance(VideoPlayer.transform.position, playerTransform.position) < 7) ? true : false;
        return result;
    }

    private bool CheckVisibility()
    {
        var screenVisible = (Video.GetComponent<Renderer>().isVisible) ? true : false;
        var menuVisible = Menu.activeSelf;
        var result = (screenVisible && !menuVisible);
        return result;
    }
}
