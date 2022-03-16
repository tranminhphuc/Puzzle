using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Game Setting")]
public class GameSetting : ScriptableObject
{
    [SerializeField]
    private int size;
    [SerializeField]
    private Vector2 startPosition;
    [SerializeField]
    private Vector2 distance;
    [SerializeField]
    private Vector2Int emptyPosition;

    public int Size => size;
    public Vector2 StartPosition => startPosition;
    public Vector2Int EmptyPosition => emptyPosition;
    public Vector2 Distance => distance;
}
