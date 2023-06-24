using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public Scene endScene;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(endScene.handle);
    }
}
