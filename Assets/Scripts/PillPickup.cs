using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillPickup : MonoBehaviour
{
    [Tooltip("The player themselves")]
    public GameObject player;
    [Tooltip("How fast it rotates around itself")]
    public float rotationSpeed;

    /// <summary>
    ///     Rotates on the Y axis infinitely
    /// </summary>
    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }

    /// <summary>
    ///     If the player touches the pill it adds to the count and Destroys it
    /// </summary>
    /// <param name="other">The Object that hit the trigger</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PillUsage>().pillAmount++;
            Destroy(gameObject);
        }
        //TODO: Play Audio
    }
}
