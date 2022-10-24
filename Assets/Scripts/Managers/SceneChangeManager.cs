using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void NavigateToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
        
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + currentScene.name + "'.");
    }

    public void NavigateToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + currentScene.name + "'.");
    }

    public void NavigateToInGame()
    {
        SceneManager.LoadScene("InGame");

        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + currentScene.name + "'.");
    }
}