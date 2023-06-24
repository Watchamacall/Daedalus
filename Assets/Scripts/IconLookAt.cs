using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconLookAt : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("The player GameObject")]
    public GameObject player;

    /// <summary>
    ///     Looks at the player constantly
    /// </summary>
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
