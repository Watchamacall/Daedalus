using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FocusingMode : MonoBehaviour
{
    //General Settings
    [Header ("General Settings")]

    [Tooltip("The map itself")]
    public GameObject map;
    //[Tooltip("This is the key you need to press in order to activate")]
    //public KeyCode focusKey = KeyCode.Period;
    [Range(1.0f, 10.0f)]
    [Tooltip("The amount of time in 'Focus'")]
    public float timeInFocus = 1.0f;
    [Range(1.0f, 10.0f)]
    [Tooltip("The amount of time needed for the 'Focus' to recharge")]
    public float timeToRecharge = 1.0f;
    [Tooltip("Uses the light instead of changing the shader")]
    public bool lightUsed;
    [Tooltip("The Audio Data which the focus sound is being held")]
    public AudioManager manager;
    [Tooltip("Name of the audio you want to play when the Focus is usable again")]
    public string focusUsableAudio;

    //Image Settings
    [Header("Image Settings")]

    [Tooltip("The image in which the GUI will show")]
    public GameObject FocusHUD;


    //Shader Settings
    [Header ("Shader Settings")]

    [Tooltip("The material you want the walls to turn")]
    public Shader noShader;

    //Light Settings
    [Header ("Light Settings")]

    [Tooltip("The main light for the character")]
    public Light viewLight;
    [Range (10.0f, 100.0f)]
    [Tooltip("The max range of the range of the light")]
    public float lightRangeMax = 10.0f;

    //Hiding these elements from the inspector
    [HideInInspector]
    Image GUIImage;
    bool focusUsable = true;

    [SerializeField]
    private Controls inputController;

    GameObject[] wallChildren;
    Shader[] childShader;
    Material[] childMats;

    /// <summary>
    ///     Runs on the first frame
    /// </summary>
    private void Start()
    {
        GUIImage = FocusHUD.GetComponent<Image>();

        wallChildren = GetAllChildren(map);
        childMats = GetMaterials(wallChildren);
        childShader = GetShaders(wallChildren);
    }

    /// <summary>
    ///     Press key to activate the Focus Mode
    /// </summary>
    void Update()
    {
        if (inputController.PlayerFocused() && focusUsable)
        {
            if (!lightUsed)
            {
                var meshRenderer = map.GetComponent<MeshRenderer>();

                StartCoroutine(FocusTime(meshRenderer, timeInFocus));
            }
            else
            {
                StartCoroutine(FocusTime(viewLight, timeInFocus));
            }

        }
    }

    public GameObject[] GetAllChildren(GameObject parent)
    {
        List<GameObject> walls = new List<GameObject>();

        foreach (Transform item in parent.transform)
        {
            walls.Add(item.gameObject);
        }

        return walls.ToArray();
    }

    public Material[] GetMaterials(GameObject[] children)
    {
        List<Material> childMat = new List<Material>();

        foreach (var material in children)
        {
            foreach (var item in material.GetComponent<MeshRenderer>().materials)
            {
                childMat.Add(item);
            }
        }
        return childMat.ToArray();
    }
    public Shader[] GetShaders(GameObject[] children)
    {
        List<Shader> childShaders = new List<Shader>();
        foreach (GameObject item in children)
        {
            foreach (var materials in item.GetComponent<MeshRenderer>().materials)
            {
                childShaders.Add(materials.shader);
            }
        }
        return childShaders.ToArray();
    }





    /// <summary>
    ///     This changes the material to a No Shader allowing for the user to see the walls
    /// </summary>
    /// <param name="mesh">The mesh renderer</param>
    /// <param name="duration">The duration of the focus</param>
    IEnumerator FocusTime(MeshRenderer mesh, float duration)
    {
        GUIImage.color = new Color(255,255,255,0); //Changes the GUI to transparent

        float time = 0;
        focusUsable = false;


        Shader currentMapShader = wallChildren[0].GetComponent<MeshRenderer>().material.shader;

        //Setting the children to be noShader
        foreach (var material in childMats)
        {
            material.shader = noShader;
        }

        while (time < duration)
        {
            time += Time.deltaTime;
            yield return null;
        }

        foreach (var material in childMats)
        {
            material.shader = currentMapShader;
        }

        StartCoroutine(RechargeTime(timeToRecharge));
    }

    /// <summary>
    ///     This changes the light range of the viewLight to max range, allowing for a percieved 'max view'
    /// </summary>
    /// <param name="mainLight">The light in which you want to change</param>
    /// <param name="duration">How long you want it to go on for</param>
    /// <returns></returns>
    IEnumerator FocusTime(Light mainLight, float duration)
    {
        GUIImage.color = new Color(GUIImage.color.r, GUIImage.color.g, GUIImage.color.b, 0);

        float time = 0;
        focusUsable = false;

        float currentLightRange = mainLight.range;

        while (time < duration)
        {
            mainLight.range = Mathf.Lerp(mainLight.range, lightRangeMax, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        mainLight.range = currentLightRange;

        StartCoroutine(RechargeTime(timeToRecharge));
    }

    /// <summary>
    ///     This is used to 'recharge' the focus mode
    /// </summary>
    /// <param name="chargeTime">The time you want for the Focus Mode to recharge</param>
    /// <returns>Nothing</returns>
    IEnumerator RechargeTime(float chargeTime)
    {
        float time = 0;

        while (time < chargeTime)
        {
            GUIImage.color = new Color(GUIImage.color.r,GUIImage.color.g,GUIImage.color.b, Mathf.Lerp(0.0f, 1.0f, time / chargeTime)); //Slowly increases the GUI to be more seeable

            time += Time.deltaTime;
            yield return null;
        }

        focusUsable = true;
        GUIImage.color = Color.yellow;

        manager.Play(manager.GetPiece(focusUsableAudio));
    }
}
