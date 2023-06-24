using UnityEngine.Audio;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
///     The Audio location and holding the audio clips
/// </summary>
public class AudioLocation
{
    public List<AudioClip> audioArray { get; set; }
    public string audioSourceLocation { get; set; }

    public AudioLocation()
    {
        audioArray = new List<AudioClip>();
    }
}

[System.Serializable]
public class Sound
{
    [Tooltip("The name of the sound")]
    public string name;
    [Tooltip("The audio clip itself")]
    public AudioClip clip;

    [Tooltip("The volume of the clip (1 is default)")]
    [Range(0f, 1f)]
    public float volume = 1f;
    [Tooltip("The pitch of the clip (1 is default)")]
    [Range(-3f, 3f)]
    public float pitch = 1f;
    [Tooltip("Tick this is you want it to have the audio just be 3D (Not one of the narrators)")]
    public bool spacial = true;
    [Tooltip("Left Narrator (Only pick one)")]
    public bool leftNarrator;
    [Tooltip("Right Narrator (Only pick one)")]
    public bool rightNarrator;

    [HideInInspector]
    public AudioSource source;
}