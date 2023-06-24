using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneNames
{
    StartScreen,
    SampleScene,
    LevelPrefab,
    Forest_Maze,
    Experimental,
    EndScreen,
    DesertMaze,
    DeathScene,
    RealityMaze
}

public class SceneLoader : MonoBehaviour
{
    [Tooltip("Choose the name of the scene you want to load")]
    public SceneNames scene;
    /// <summary>
    ///     Loads the next scene in the build
    /// </summary>
    public void LoadGame()
    {
        SceneManager.LoadScene(scene.ToString());
    }

    /// <summary>
    ///     Quits the application (works when built)
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}

