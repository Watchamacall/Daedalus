using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingColours : MonoBehaviour
{
    [Tooltip("The GameObject that the panel is")]
    public GameObject panel;
    [Tooltip("The colour you want the panel to change to")]
    public Color colourToChangeTo = new Color(255,255,255);
    [Range(1.0f, 10.0f)]
    [Tooltip("This is how fast the colour will change (Lower means faster)")]
    public float colourChangeSpeed = 1.0f;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ChangeColour(colourToChangeTo, colourChangeSpeed));
        }
    }

    /// <summary>
    ///     Changes the colour of the panel into the one given
    /// </summary>
    /// <param name="endColour">The colour you want to change the panel to</param>
    /// <param name="duration">How fast the colour will change</param>
    /// <returns>Nothing</returns>
    IEnumerator ChangeColour(Color endColour, float duration)
    {
        float time = 0;
        Color startValue = panel.GetComponent<Image>().color;

        while (time < duration)
        {
            panel.GetComponent<Image>().color = Color.Lerp(startValue, endColour, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        panel.GetComponent<Image>().color = endColour;
    }
}
