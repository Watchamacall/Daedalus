using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingAmbientLight : MonoBehaviour
{
    [Tooltip("The colour you want the skybox to change to")]
    public Color skyboxColour;
    [Tooltip("The colour you want the camera lighting to change to")]
    public Color cameraColour;
    [Tooltip("The GameObject you want it to become next active")]
    public GameObject nextActive;
    [Tooltip("The narrator manager")]
    public AudioManager narratorManager;
    [Tooltip("The name of the hub which holds all the specific colour voice lines")]
    public string colourHub;
    [Tooltip("Whether or not this is the last one")]
    public bool end;

    [ContextMenu("Change Colour")]
    public void Go()
    {
        ChangeAmbientLight(skyboxColour);
        ChangeCamera(cameraColour);
    }

    [ContextMenu("Reset Lighting")]
    public void ResetLight()
    {
        ChangeAmbientLight(Color.black);
        ChangeCamera(Color.black);
    }

    public void ChangeAmbientLight(Color colour) //Changes the colour of the ambient light
    {
        RenderSettings.ambientLight = colour;
    }

    public void ChangeCamera(Color colour) //Changes colour of the camera skybox
    {
        Camera.main.backgroundColor = colour;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Go();

            if (nextActive != null)
            {
                nextActive.SetActive(true);
            }

            if (end)
            {
                GetComponent<SceneLoader>().LoadGame();
            }
            else
            {
                narratorManager.PlayHub(narratorManager.GetHub(colourHub));
            }

            Destroy(this.gameObject);

        }
    }
}
