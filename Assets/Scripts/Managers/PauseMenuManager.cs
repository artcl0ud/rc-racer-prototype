using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        string reqSceneName = "InGame";
        Scene currentScene = SceneManager.GetActiveScene();
        bool canOpenMenuToggle = false;
        bool menuIsOpen = false;

        Debug.Log("Active Scene is '" + currentScene.name + "'.");

        if (currentScene.name == reqSceneName)
        {
            canOpenMenuToggle = true;

            if (canOpenMenuToggle == true && Input.GetKeyDown(KeyCode.Escape))
            {
                menuIsOpen = true;
                this.gameObject.GetComponent<Canvas>().enabled = true;
            }
            if (menuIsOpen = true && Input.GetKeyUp(KeyCode.Escape))
            {
                menuIsOpen = false;
                this.gameObject.GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
