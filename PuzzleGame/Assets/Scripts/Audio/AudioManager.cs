using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip clickAudio;
    public AudioClip endGameAudio;

    public AudioSource musicSource;
    public AudioSource soundSource;

    private void Awake()
    {
        Picture.onClick += OnPictureClick;
        GameStateManager.Instance.onGameStateChanged += OnGameStateChanged;

        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        soundSource.volume = PlayerPrefs.GetFloat("SoundVolume", 1.0f);
    }

    private void OnDestroy()
    {
        Picture.onClick -= OnPictureClick;
        GameStateManager.Instance.onGameStateChanged -= OnGameStateChanged;
    }

    public void EndGame()
    {
        musicSource.PlayOneShot(endGameAudio);
    }

    private void OnPictureClick(Picture picture)
    {
        musicSource.PlayOneShot(clickAudio);
    }

    private void OnGameStateChanged(GameState gameState)
    {
        if(gameState == GameState.PauseGame || gameState == GameState.EndGame)
        {
            musicSource.volume = 0f;
            soundSource.volume = 0f;
        }

        if(gameState == GameState.PlayingGame)
        {
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
            soundSource.volume = PlayerPrefs.GetFloat("SoundVolume", 1.0f);
        }
    }
}
