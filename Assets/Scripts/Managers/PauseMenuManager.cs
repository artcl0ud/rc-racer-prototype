using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public Canvas pauseMenu;
    public Scene currentScene;
    
    // Start is called before the first frame update
    private void Awake() 
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("Current active scene is '" + currentScene.name + "'.");
        
        pauseMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.enabled = !pauseMenu.enabled;
        }
    }
}
