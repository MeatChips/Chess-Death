using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedTimer : MonoBehaviour
{
    public static RedTimer Instance;

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
            if (GameManager.Instance.GameState == GameState.RedTurn)
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
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
