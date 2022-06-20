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

    // The gamestates of the game, what is happening in the game
    public void UpdateGameStates(GameState newState)
    {
        GameState = newState;

        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnBothTeams:
                UnitsManager.Instance.SpawnUnits();
                break;
            case GameState.BlueTurn:
                break;
            case GameState.RedTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState{
    GenerateGrid = 0,
    SpawnBothTeams = 1,
    BlueTurn = 2,
    RedTurn = 3
}
