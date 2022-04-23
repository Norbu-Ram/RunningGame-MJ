using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    [SerializeField] Slider volume;

    [SerializeField] AudioSource mainSound;
    [SerializeField] Text percentage;
    void Start()
    {
        mainSound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        float value = PlayerPrefs.GetFloat("CurrentVolume", 0);

            mainSound.volume = value;
            volume.value = value;
            percentage.text = PlayerPrefs.GetString("Percentage") + "%";
    }
    public void onSliderValueChange()
    {
        mainSound.volume = volume.value;
        PlayerPrefs.SetFloat("CurrentVolume", mainSound.volume);

        float value = (int)(volume.value * 100);

        percentage.text = value.ToString() + "%";
        PlayerPrefs.SetString("Percentage", value.ToString());
    }
}
