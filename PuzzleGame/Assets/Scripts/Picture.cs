using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Picture : MonoBehaviour
{
    public static event Action<Picture> onClick;

    public Vector2Int CurrentPosition => currentPosition;

    private Vector2Int originPosition;
    private Vector2Int currentPosition;

    private void OnMouseDown()
    {
        onClick?.Invoke(this);
    }

    private void OnDestroy()
    {
        Addressables.Release(gameObject);
    }

    public void MoveTo(Vector3 target)
    {
        transform.position = target;
    }

    public void SetOriginPosition(Vector2Int position)
    {
        originPosition = position;
        currentPosition = position;
    }

    public void SetPosition(int rowIndex, int colIndex)
    {
        currentPosition = new Vector2Int(rowIndex, colIndex);
    }

    public void SetPosition(Vector2Int position)
    {
        currentPosition = position;
    }

    public bool CheckOriginPosition()
    {
        return originPosition == currentPosition;
    }
}
