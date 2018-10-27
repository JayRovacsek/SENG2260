using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(Button))]
public class MediaPlayerPlayButton : MonoBehaviour {
    public GameObject source;
    public Sprite pauseSprite;
    private MediaPlayerController Player { get; set; }

	// Use this for initialization
	void Start () {
		if (source == null)
        {
            source = gameObject.transform.parent.gameObject;
        }

        if (source != null)
        {
            Player = source.GetComponent<MediaPlayerController>();
        }

        if (Player == null)
        {
            Player = source.AddComponent<MediaPlayerController>();
            Player.audioSource = source.GetComponent<AudioSource>();
            Player.videoPlayer = source.GetComponent<VideoPlayer>();
        }

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Player.ToggleMediaPlayerState);
    }

    private void UpdateButtonVisibility()
    {
        Button button = gameObject.GetComponent<Button>();
        Image image = gameObject.GetComponent<Image>();

        if (Player == null || Player.videoPlayer == null)
        {
            button.interactable = false;
            return;
        }
        else
        {
            button.interactable = true;
        }

        if (image == null || pauseSprite == null)
        {
            return;
        }

        image.overrideSprite = (Player.videoPlayer.isPlaying) ? pauseSprite : null;
    }

    // Update is called once per frame
    void FixedUpdate () {
        UpdateButtonVisibility();
    }
}
