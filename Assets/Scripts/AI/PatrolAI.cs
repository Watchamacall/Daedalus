using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    public WaypointData waypointMaster;
    public NavMeshAgent agent;
    public GameObject player;
    public float radiusUntilChangeLocation;
    public float chaseRadius;
    public float searchRadius;
    public float timeTillChase;
    public WaitForSeconds chaseSeconds;


    private Vector3 currentWaypointLocation;
    private float dist;
    private float playerDist;




    private void Start()
    {

        currentWaypointLocation = waypointMaster.GetPointRandom();
        chaseSeconds = new WaitForSeconds(timeTillChase);
    }

    // Update is called once per frame
    void Update()
    {

        dist = Vector3.Distance(transform.position, currentWaypointLocation); //Get's distance from the AI to the currentWaypointLocation

        playerDist = Vector3.Distance(transform.position, player.transform.position); //Get's the distance between AI and the player

        if (dist < radiusUntilChangeLocation)
        {
            Move(waypointMaster.GetPointRandom());
        }

        if (playerDist < searchRadius)
        {
            Move(transform.position);
            
        }

        if (playerDist < chaseRadius)
        {
            Move(player.transform.position);
        }
        else
        {
            Move(currentWaypointLocation);
        }
    }

    void Move(Vector3 target)
    {
        currentWaypointLocation = target;
        agent.SetDestination(target);
    }

    public IEnumerator Search(float timeToChase)
    {
        yield return chaseSeconds;
    }
}
