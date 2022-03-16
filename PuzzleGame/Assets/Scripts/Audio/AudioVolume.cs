using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolume
{
    public static float musicVolume = 1.0f;
    public static float soundVolume = 1.0f;

    public static void Set()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }
}
