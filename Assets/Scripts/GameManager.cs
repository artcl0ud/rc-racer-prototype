using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public InputController inputController { get; private set; }

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
    }

    void Update()
    {
        ResetGame();
        QuitGame();
    }

    void QuitGame()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void ResetGame()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
