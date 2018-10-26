using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour {

    private GameObject VideoPlayer { get; set; }
    private GameObject AudioPlayer { get; set; }
    private GameObject Player { get; set; }
    private bool IsInProximity { get; set; }
    private VideoPlayer Video { get; set; }
    private AudioSource Audio { get; set; }

	// Use this for initialization
	void Start () {
        VideoPlayer = GameObject.FindWithTag("Video");
        AudioPlayer = GameObject.FindWithTag("Audio");
        Player = GameObject.FindWithTag("Player");
        Video = VideoPlayer.GetComponent<VideoPlayer>();
        Audio = AudioPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
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
                StopPlaying();
            }
        }
    }

    private void StartPlaying()
    {
        Video.Play();
        Audio.Play();
    }

    private void StopPlaying()
    {
        Video.Stop();
        Audio.Stop();
    }

    private bool CheckProximity(Transform playerTransform)
    {
        var result = (Vector3.Distance(VideoPlayer.transform.position, playerTransform.position) < 7) ? true : false;
        return result;
    }
}
