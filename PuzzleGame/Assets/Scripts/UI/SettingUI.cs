using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public GameObject settingLabel;

    public void OpenSetting()
    {
        if (GameStateManager.Instance.currentState == GameState.PlayingGame)
        {
            GameStateManager.Instance.SetState(GameState.PauseGame);
        }

        settingLabel.SetActive(true);
    }

    public void CloseSetting()
    {
        if (GameStateManager.Instance.currentState == GameState.PauseGame)
        {
            GameStateManager.Instance.SetState(GameState.PlayingGame);
        }

        settingLabel.SetActive(false);
    }


}
