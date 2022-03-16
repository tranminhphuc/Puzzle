using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    private string folder;

    public void LoadLevelMap()
    {
        AddressManager.folder = folder;
    }
}
