using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Debug.Log("SCENE LOADED");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("GAME QUIT");
    }
}
