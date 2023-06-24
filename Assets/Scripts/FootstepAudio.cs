using AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("The AudioManager which holds all the footstep Audio")]
    public AudioManager manager;

    [Tooltip("The hub in which the footstep sounds are held")]
    public string footstepHubName;

    AudioPiece[] footstepHub;

    [Tooltip("Toggles whether a random footstep is chosen or not")]
    public bool randomFootsteps;

    [Tooltip("The footstep AudioPiece if the randomFootsteps is not ticked")]
    public string footstepPieceName;

    AudioPiece footstepPiece;

    [Tooltip("How fast you have to be moving in order for the footsteps to play")]
    public float footstepSpeed;

    [Tooltip("The GameObject in which represents the footsteps")]
    public GameObject footstepGameObject;

    [Tooltip("The Empty GameObject for this foot")]
    public GameObject leftFootEmpty, rightFootEmpty;

    [Tooltip("How far apart the feet are")]
    public float feetDistance;

    private void Start()
    {
        footstepHub = manager.GetHub(footstepHubName);
        footstepPiece = manager.GetPiece(footstepPieceName);
    }


    /// <summary>
    ///     Places the footstep down
    /// </summary>
    public void FootstepPlaceDown(float left)
    {
        if (randomFootsteps)
        {
            manager.Play(manager.GetRandomPiece(footstepHub));
        }
        else
        {
            manager.Play(footstepPiece);
        }

        GameObject foot;

        if (left == 1)
        {
            foot = Instantiate(footstepGameObject, leftFootEmpty.transform.position, leftFootEmpty.transform.rotation);
            //foot.transform.localPosition = transform.position + (Vector3.forward * -feetDistance);

        }
        else
        {
            foot = Instantiate(footstepGameObject, rightFootEmpty.transform.position, rightFootEmpty.transform.rotation);

            //foot.transform.localPosition = transform.position + (Vector3.forward * feetDistance);
            foot.transform.localScale = new Vector3(-foot.transform.localScale.x, foot.transform.localScale.y, foot.transform.localScale.z);

        }

        foot.transform.Rotate(0, 180, 0);
    }
}
