using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchIncrease : MonoBehaviour
{
    [Header("Light Settings")]
    [Tooltip("The Light that you want to change the range on")]
    public Light touchLight;
    [Range(0.0f, 10.0f)]
    [Tooltip("Time to take to light up the wall")]
    public float timeToLightUp;
    [Range(0.0f, 10.0f)]
    [Tooltip("Time to take to unlight the wall")]
    public float timeToDecreaseLight;
    [Range(1.0f, 10.0f)]
    [Tooltip("The range of light")]
    public float lightRange;
    
    [Header("Audio Settings")]
    [Tooltip("The audio clip you want to play when you hit the wall")]
    public string wallHitAudio;
    [Tooltip("The Audio Data which the Touch sound is held")]
    public AudioManager manager;

    [HideInInspector]
    Coroutine onWall, offWall;

    /// <summary>
    ///     When you enter the collision the range increases
    /// </summary>
    /// <param name="collision">The collision that the player hits</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (!manager.GetPiece(wallHitAudio).source.isPlaying)
            {
                manager.Play(manager.GetPiece(wallHitAudio));
            }

            onWall = StartCoroutine(IntensityIncrease(timeToLightUp, touchLight.range, lightRange));

            StopCoroutine(offWall);
            
        }
    }

    /// <summary>
    ///     When you exit the collision the range turns to 0
    /// </summary>
    /// <param name="collision">The collision the player hits</param>
    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            StopCoroutine(onWall);

            offWall = StartCoroutine(IntensityIncrease(timeToDecreaseLight, touchLight.range, 0));
        }
    }

    /// <summary>
    ///     Lerps the lights to slowly increase the range
    /// </summary>
    /// <param name="timeToLightUp">The time needed for the lights to increase</param>
    /// <returns>Nothing</returns>
    IEnumerator IntensityIncrease (float timeToLightUp, float minRange, float maxRange)
    {

        float time = 0;

        while (time < timeToLightUp)
        {
            touchLight.range = Mathf.Lerp(minRange, maxRange, time / timeToLightUp);

            time += Time.deltaTime;
            yield return null;
        }
    }
}
