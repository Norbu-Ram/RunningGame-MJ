using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable ]
public class Sound 
{
    public string name;
    public AudioClip audio;
    public bool loop;
    public bool playOnWake;

    [Range(0,1)]
    public float  volume =0.5f;
    public  AudioSource audioSource;
}
