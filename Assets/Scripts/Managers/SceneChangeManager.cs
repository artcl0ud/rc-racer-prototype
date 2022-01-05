using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void NavigateToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void NavigateToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}