using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState GameState;

    // Colors for background changes
    Color BlueColor = Color.blue;
    Color RedColor = Color.red;

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
                Camera.main.backgroundColor = BlueColor;
                break;
            case GameState.RedTurn:
                Camera.main.backgroundColor = RedColor;
                break;
            case GameState.BlueWin:
                MenuManager.Instance.TeamBlueWon();
                break;
            case GameState.RedWin:
                MenuManager.Instance.TeamRedWon();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

// GameState enums
public enum GameState{
    GenerateGrid = 0,
    SpawnBothTeams = 1,
    BlueTurn = 2,
    RedTurn = 3,
    BlueWin = 4,
    RedWin = 5
}