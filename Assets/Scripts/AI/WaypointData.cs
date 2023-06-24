using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WayPoint", menuName = "Custom/Waypoint Data", order = 1)]
public class WaypointData : ScriptableObject
{
    public List<Vector3> points = new List<Vector3>();

    private int pos = 0;

    public Vector3 GetPointRandom()
    {
        int rnd = Random.Range(0, points.Count);
        return points[rnd];
    }

    public Vector3 GetPointRoundRobin()
    {
        int curPos = pos;
        pos = (pos + 1 >= points.Count) ? 0 : pos + 1;

        return points[curPos];
    }

    public Vector3 GetClosestPoint(Vector3 target)
    {
        float lastDist = Mathf.Infinity;
        int finalId = 0;

        for (int i = 0; i < points.Count; i++)
        {
            float dist = Vector3.Distance(target, points[i]);
            if(lastDist > dist)
            {
                lastDist = dist;
                finalId = i;
            }
        }

        return points[finalId];
    }
}
