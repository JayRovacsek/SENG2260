using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CourseResource : MonoBehaviour
{
    [SerializeField]
    public CourseResourceType type;
    [SerializeField]
    public string course;   
    [SerializeField]
    public VideoClip video;
    [SerializeField]
    public AudioSource audio;
    [SerializeField]
    public CourseResource next;
}
