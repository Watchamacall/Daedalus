using AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatDistance : MonoBehaviour
{
    [Tooltip("The player GameObject (Finds automatically if null)")]
    public GameObject player;
    [Tooltip("The AudioManager which holds the playerSFX manager")]
    public AudioManager playerSFXManager;
    [Tooltip("The piece name for the heartbeat")]
    public string heartbeatPiece;
    AudioPiece heartbeat;

    [Header("DEBUG")]
    public float distanceToEnemy;
    public float totalPitch;

    private void Awake()
    {
        heartbeat = playerSFXManager.GetPiece(heartbeatPiece);
    }

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }


    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        //Debug.Log(distance);

        heartbeat.source.pitch = -MapIntToFloat((int)distance, 0, 25, -2, -0.5f);
    }

    [ContextMenu("MapIntToFloat")]
    public void distanceCheck()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        Debug.Log(distance);

        totalPitch = MapIntToFloat((int)distance, 0, 25, -2, -0.5f);
    }

    float MapIntToFloat(int inputValue, float fromMin, float fromMax, float toMin, float toMax)
    {
        float i = ((((float)inputValue - fromMin) / (fromMax - fromMin)) * (toMax - toMin) + toMin);
        i = Mathf.Clamp(i, toMin, toMax);
        return i;
    }
}