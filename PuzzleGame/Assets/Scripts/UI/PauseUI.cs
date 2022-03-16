using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PauseUI : MonoBehaviour
{
    public Sprite playImage;
    public Sprite pauseImage;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Pause()
    {
        if(GameStateManager.Instance.currentState == GameState.PlayingGame)
        {
            GameStateManager.Instance.SetState(GameState.PauseGame);
            image.sprite = pauseImage;
            return;
        }

        if(GameStateManager.Instance.currentState == GameState.PauseGame)
        {
            GameStateManager.Instance.SetState(GameState.PlayingGame);
            image.sprite = playImage;
        }
    }
}
