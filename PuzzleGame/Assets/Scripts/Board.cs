using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private Picture[,] allPicture;
    private List<Vector2Int> positionList = new List<Vector2Int>();

    private GameSetting gameSetting;

    public void CreateBoard()
    {
        if (!gameSetting)
        {
            Debug.LogError("Chua load setiing");
            return;
        }

        allPicture = new Picture[gameSetting.Size, gameSetting.Size];
        LoadPositionList();
    }

    public void OnClickPicture(Picture picture)
    {
        Vector2Int targetPosition = picture.CurrentPosition;

        if (picture.CurrentPosition.y - 1 >= 0 && !allPicture[picture.CurrentPosition.x, picture.CurrentPosition.y - 1])
        {
            targetPosition.y = picture.CurrentPosition.y - 1;
        }

        if (picture.CurrentPosition.y + 1 < gameSetting.Size && !allPicture[picture.CurrentPosition.x, picture.CurrentPosition.y + 1])
        {
            targetPosition.y = picture.CurrentPosition.y + 1;
        }

        if (picture.CurrentPosition.x - 1 >= 0 && !allPicture[picture.CurrentPosition.x - 1, picture.CurrentPosition.y])
        {
            targetPosition.x = picture.CurrentPosition.x - 1;
        }

        if (picture.CurrentPosition.x + 1 < gameSetting.Size && !allPicture[picture.CurrentPosition.x + 1, picture.CurrentPosition.y])
        {
            targetPosition.x = picture.CurrentPosition.x + 1;
        }

        allPicture[picture.CurrentPosition.x, picture.CurrentPosition.y] = null;
        SetPostionOfPicture(picture, targetPosition.x, targetPosition.y);
    }

    public void SetupPicture(Picture picture)
    {
        picture.GetComponent<BoxCollider2D>().size = new Vector2(gameSetting.Distance.x, gameSetting.Distance.y);
        RandomPicture(picture);
    }

    public void LoadGameSetting(GameSetting gameSetting)
    {
        this.gameSetting = gameSetting;
    }

    public bool CheckEmptyPosition(int row, int col)
    {
        if (row == gameSetting.EmptyPosition.x && col == gameSetting.EmptyPosition.y)
        {
            return true;
        }
        return false;
    }

    private void RandomPicture(Picture picture)
    {
        int random = Random.Range(0, positionList.Count);
        Vector2Int targetPosition = positionList[random];
        positionList.Remove(targetPosition);
        SetPostionOfPicture(picture, targetPosition.x, targetPosition.y);
        if (positionList.Count == 0) GameStateManager.Instance.SetState(GameState.PlayingGame);
    }

    private void SetPostionOfPicture(Picture picture, int rowIndex, int colIndex)
    {
        allPicture[rowIndex, colIndex] = picture;
        Vector3 targerPosition = new Vector3(
            gameSetting.StartPosition.x + gameSetting.Distance.y * colIndex,
            gameSetting.StartPosition.y - gameSetting.Distance.x * rowIndex,
            0f
        );

        picture.MoveTo(targerPosition);
        picture.SetPosition(rowIndex, colIndex);
    }

    private void LoadPositionList()
    {
        for(int i = 0; i < gameSetting.Size; i++)
        {
            for(int j = 0; j < gameSetting.Size; j++)
            {
                if (CheckEmptyPosition(i, j)) continue;
                positionList.Add(new Vector2Int(i, j));
            }
        }
    }

    public bool CheckPictureMap()
    {
        for (int i = 0; i < gameSetting.Size; i++)
        {
            for (int j = 0; j < gameSetting.Size; j++)
            {
                if (!allPicture[i, j]) continue;
                if (!allPicture[i, j].CheckOriginPosition()) return false;
            }
        }

        return true;
    }
}
