using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEndLoad : MonoBehaviour
{
    public string hubName;
    private void OnEnable()
    {
        GameObject.Find("AudioManager - Narration").GetComponent<AudioManager>().PlayHub(hubName);
    }
}
