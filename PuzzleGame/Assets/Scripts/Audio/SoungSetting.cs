using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoungSetting : AudioSetting
{
    private void Awake()
    {
        Debug.Log(AudioVolume.soundVolume);
        audioSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1.0f);
        currentSliderValue = audioSlider.value;
    }

    public override void ChangeAudioSliderValue()
    {
        AudioVolume.soundVolume = audioSlider.value;
        PlayerPrefs.SetFloat("SoundVolume", audioSlider.value);
        Debug.Log(AudioVolume.soundVolume);
    }
}
