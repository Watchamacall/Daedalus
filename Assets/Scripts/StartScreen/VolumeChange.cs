using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeChange : MonoBehaviour
{
    public AudioManager manager;
    public void VolumeChanged(System.Single vol)
    {
        AudioListener.volume = vol;
        manager.Play(manager.GetRandomPiece(manager.audioHub[Random.Range(0,manager.audioHub.Length)].audioPieces));
    }
}
