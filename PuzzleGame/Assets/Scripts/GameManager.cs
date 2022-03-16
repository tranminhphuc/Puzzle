using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private Board board;

    [SerializeField]
    private StarHandler starHandler;

    private bool pause = false;
    private bool endGame = false;

    private float maxClick = 0f;
    private float numberClick = 0f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        if (Instance != this) Destroy(gameObject);

        Picture.onClick += OnClickPicture;
        GameStateManager.Instance.onGameStateChanged += OnGameStateChanged;
        GameStateManager.Instance.SetState(GameState.StartGame);
    }

    private void OnDestroy()
    {
        Picture.onClick -= OnClickPicture;
        GameStateManager.Instance.onGameStateChanged -= OnGameStateChanged;
    }

    public void LoadGameSetting(GameSetting gameSetting)
    {
        board.LoadGameSetting(gameSetting);
        board.CreateBoard();

        maxClick = gameSetting.Size * gameSetting.Size * 4;
    }

    public void SetupPicture(Picture picture, Vector2Int position)
    {
        picture.SetOriginPosition(position);
        board.SetupPicture(picture);
    }

    public bool CheckEmptyPosition(int row, int col)
    {
        return board.CheckEmptyPosition(row, col);
    }

    private void OnClickPicture(Picture picture)
    {
        if (pause || endGame) return;
        board.OnClickPicture(picture);
        numberClick++;

        if(board.CheckPictureMap())
        {
            GameStateManager.Instance.SetState(GameState.PauseGame);
            endGame = true;
            float percenge = numberClick / maxClick * 100f;
            starHandler.StartStarAnimation(percenge);
        }
    }

    private void OnGameStateChanged(GameState gameState)
    {
        if(gameState == GameState.PauseGame)
            pause = true;

        if (gameState == GameState.PlayingGame)
            pause = false;
    }
}
