using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState GameState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameStates(GameState.GenerateGrid);
    }

    public void UpdateGameStates(GameState newState)
    {
        GameState = newState;

        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnBlue:
                UnitsManager.Instance.SpawnBlue();
                break;
            case GameState.SpawnRed:
                UnitsManager.Instance.SpawnRed();
                break;
            case GameState.RedTurn:
                break;
            case GameState.BlueTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState{
    GenerateGrid = 0,
    SpawnBlue = 1,
    SpawnRed = 2,
    RedTurn = 3,
    BlueTurn = 4
}
