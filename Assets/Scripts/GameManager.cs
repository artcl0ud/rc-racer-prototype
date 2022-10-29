using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public InputController inputController { get; private set; }
    public Scene currentScene;

    //UI
    public Canvas pauseMenu;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;   
        }

        DontDestroyOnLoad(this.gameObject);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        inputController = GetComponentInChildren<InputController>();
        currentScene = SceneManager.GetActiveScene();

        pauseMenu.enabled = false;
    }

    void Update()
    {
        PauseGame();
        ResetGame();
        //QuitGame();
    }

    // void QuitGame()
    // {
    //     if(Input.GetKeyUp(KeyCode.Escape))
    //     {
    //         Application.Quit();
    //     }
    // }

    void ResetGame()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void PauseGame()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.enabled = !pauseMenu.enabled;
        }
    }
}
