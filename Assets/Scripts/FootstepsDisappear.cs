using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsDisappear : MonoBehaviour
{
    [Tooltip("How long until the footsteps disappear in seconds")]
    public float deathTime = 2;
    [Tooltip("How fast the alpha value decreases")]
    public float alphaValue;

    [HideInInspector]
    public bool left; //Whether or not to invert it

    void Start()
    {
        StartCoroutine(FootstepHalfLife(deathTime));
    }

    /// <summary>
    ///     Counts up and destroys the GameObject after the given time
    /// </summary>
    /// <param name="timeToDie">How long until the GameObject gets Destroyed</param>
    /// <returns>N/A</returns>
    public IEnumerator FootstepHalfLife(float timeToDie)
    {
        float time = 0;

        while (time < timeToDie)
        {
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
