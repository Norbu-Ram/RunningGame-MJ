using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    static AudioManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject );
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.loop = s.loop;
            s.audioSource.clip = s.audio;
            s.audioSource.volume  =0.5f ;
            s.audioSource.playOnAwake = s.playOnWake;
        }

      //  playSound("Menu");
    }
    public void playSound(string soundName)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == soundName)
            {
                s.audioSource.Play();
            }
        }
    }
}
