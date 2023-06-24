using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PillUsage : MonoBehaviour
{
    [Header("General Settings")]
    //[Tooltip("What key is used to activate the pill function")]
    //public KeyCode usePillButton = KeyCode.R;
    [Tooltip("The amount of pills the player currently has")]
    public int pillAmount = 0;
    [Tooltip("The icon on the enemy")]
    public GameObject icon;
    [Tooltip("How long the function will be active for")]
    public float activeTime;
    [Tooltip("How close you have to be for the function to show the icon")]
    public float distanceNeededToBeActive;
    [Tooltip("The text on the UI for showing the amount of pills")]
    public TextMeshProUGUI textField;

    [SerializeField]
    private Controls inputController;
    Coroutine mainCoroutine; //Just the coroutine, allows for it to be stopped abruptly

    void Update()
    {
        if (inputController.PlayerPilled() && pillAmount > 0 && mainCoroutine == null)
        {
            pillAmount--;
            mainCoroutine = StartCoroutine(PillActive(activeTime));
        }

        textField.text = pillAmount.ToString();
    }
    
    /// <summary>
    ///     The pill function itself, allows for the player to see the monster's icon when in a certain radius of it
    /// </summary>
    /// <param name="activeTime">How long the function will be active for</param>
    /// <returns>N/A</returns>
    public IEnumerator PillActive(float activeTime)
    {
        float time = 0;

        while (time < activeTime)
        {

            Debug.Log(Vector3.Distance(transform.position, icon.transform.position));
            if (Vector3.Distance(transform.position, icon.transform.position) < distanceNeededToBeActive)
            {
                icon.SetActive(true);
            }
            else
            {
                icon.SetActive(false);
            }

            time += Time.deltaTime;
            yield return null;
        }
        icon.SetActive(false);
        mainCoroutine = null;
    }
}
