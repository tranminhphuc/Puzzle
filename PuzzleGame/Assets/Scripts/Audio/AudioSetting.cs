using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AudioSetting : MonoBehaviour
{
    public Image audioImage;
    public Slider audioSlider;

    public Sprite turnOnSprite;
    public Sprite turnOffSpite;

    public float currentSliderValue;
    protected bool turnOn = true;

    public abstract void ChangeAudioSliderValue();

    public void ClickAudioButton()
    {
        if (turnOn)
        {
            turnOn = !turnOn;
            TurnOffAudio();
            return;
        }

        turnOn = !turnOn;
        TurnOnAudio();
    }

    protected void ChangeAudioImage()
    {
        if (audioSlider.value == 0f) audioImage.sprite = turnOffSpite;
        else audioImage.sprite = turnOnSprite;
    }

    void TurnOffAudio()
    {
        currentSliderValue = audioSlider.value;
        audioSlider.value = 0f;
        ChangeAudioImage();
    }

    void TurnOnAudio()
    {
        audioSlider.value = currentSliderValue;
        ChangeAudioImage();
    }
}
