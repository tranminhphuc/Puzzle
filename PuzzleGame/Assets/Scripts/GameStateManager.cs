using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
    private static GameStateManager instance;
    public static GameStateManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameStateManager();
            }

            return instance;
        }
    }

    public delegate void GameStateChangeHandler(GameState gameState);
    public event GameStateChangeHandler onGameStateChanged;

    public GameState currentState { get; private set; }

    private GameStateManager()
    {

    }

    public void SetState(GameState newGameState)
    {
        currentState = newGameState;
        onGameStateChanged?.Invoke(newGameState);
    }
}
