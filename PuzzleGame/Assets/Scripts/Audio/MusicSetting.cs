using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSetting : AudioSetting
{
    private void Awake()
    {
        audioSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        currentSliderValue = audioSlider.value;
        ChangeAudioImage();
    }

    public override void ChangeAudioSliderValue()
    {
        AudioVolume.musicVolume = audioSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", audioSlider.value);
        ChangeAudioImage();
    }
}
