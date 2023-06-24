using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool ScreenPaused;
    public Controls PlayerInput;

    void Start()
    {
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        if (PlayerInput.PlayerPause())
        {
            return;
        }
        if (ScreenPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        ScreenPaused = true;
        // Audio pause code 
       // AudioListener.pause = true;

    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        ScreenPaused = false;
         // Audio pause code 
       // AudioListener.pause = false;
    }

    public void GoToStartScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

  
}  