using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWaypoint : MonoBehaviour
{
    [Tooltip("The waypoints in which you want the player to teleport to")]
    public WaypointData waypoints;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = waypoints.GetPointRandom();
    }
}
