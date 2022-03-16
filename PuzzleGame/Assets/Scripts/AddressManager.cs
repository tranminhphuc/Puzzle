using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressManager : MonoBehaviour
{
    public static string folder = "Easy";

    [SerializeField]
    private AssetReference picturePrefab;

    [SerializeField]
    private Image fullPicture;

    List<AsyncOperationHandle<Sprite>> spriteHandler = new List<AsyncOperationHandle<Sprite>>();

    private void Start()
    {
        Addressables.InitializeAsync().Completed += onComplete;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < spriteHandler.Count; i++)
        {
            Addressables.Release(spriteHandler[i]);
        }
    }

    private void onComplete(AsyncOperationHandle<IResourceLocator> obj)
    {
        Addressables.LoadAssetAsync<GameSetting>(folder + "/GameSetting").Completed += (setting) =>
        {
            OnDataLoadComplete(setting.Result);
        };
    }

    void OnDataLoadComplete(GameSetting setting)
    {
        GameManager.Instance.LoadGameSetting(setting);
        LoadCompletePicture();
        LoadPictureOnBoard(setting.Size);
    }

    private void LoadPictureOnBoard(int boardSize)
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                if (GameManager.Instance.CheckEmptyPosition(i, j)) continue;

                Vector2Int position = new Vector2Int(i, j);
                int index = i * boardSize + j;

                picturePrefab.InstantiateAsync().Completed += (picture) =>
                {
                    SetupPicture(picture, position, index);
                };
            }
        }
    }

    private void LoadCompletePicture()
    {
        Addressables.LoadAssetAsync<Sprite>(folder + "/FullPicture").Completed += (picture) =>
        {
            fullPicture.sprite = picture.Result;
        };
    }

    private void SetupPicture(AsyncOperationHandle<GameObject> pictureHandler, Vector2Int position, int index)
    {
        Picture picture = pictureHandler.Result.GetComponent<Picture>();
        GameManager.Instance.SetupPicture(picture, position);
        LoadSprite(pictureHandler.Result, index);
    }

    private void LoadSprite(GameObject newPicture, int index)
    {
        Addressables.LoadAssetAsync<Sprite>(folder + "/" + (index + 1)).Completed += (sprite) =>
        {
            spriteHandler.Add(sprite);
            newPicture.GetComponent<SpriteRenderer>().sprite = sprite.Result;
        };
    }
}
