using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueTimer : MonoBehaviour
{
    public static BlueTimer Instance;

    public float timeValue = 1800;
    public Text timeText;
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (timeValue > 0)
        {
            if (GameManager.Instance.GameState == GameState.BlueTurn)
            {
                timeValue -= Time.deltaTime;
            }
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            Debug.Log("BlueTimer is zero");
            GameManager.Instance.UpdateGameStates(GameState.RedWin);
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
