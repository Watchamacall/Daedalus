using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AudioSystem;
public class EnemyAI : MonoBehaviour
{

    [Header("General Settings")]
    public AudioManager monsterManager;
    public AudioManager narratorManager;
    [Tooltip("The WaypointData that you used to setup the waypoints")]
    public WaypointData waypoints;
    [Tooltip("The player themselves")]
    public GameObject player;

    [Tooltip("The animator for the enemy")]
    public Animator animator;

    [Header("Distance Settings")]
    [Tooltip("How close the AI has to get to the waypoint in order for it to change points")]
    public float changeWaypointDistance = 0f;
    [Tooltip("How close the player has to be before the AI starts searching for them")]
    public float searchForTargetRange = 0f;
    [Tooltip("How close the player has to be before the AI starts chasing them")]
    public float chaseTargetRange = 0f;
    [Tooltip("How far away the player must be for the AI to stop chasing and search for them")]
    public float maxChaseDistance = 0f;

    [Header("Searching Settings")]
    [Tooltip("How long the AI searches for the player before going back to Roaming")]
    public float searchingTime = 0f;
    [Tooltip("How far the AI can see forward")]
    public float monsterViewDistance = 0f;

    [Header("Audio Settings")]
    [Tooltip("The names of the audio")]
    public string searchHub;
    AudioPiece[] searchAudio;

    [Tooltip("The names of the audio")]
    public string roamHub;
    AudioPiece[] roamAudio;
    
    [Tooltip("The names of the audio")]
    public string chaseHub;
    AudioPiece[] chaseAudio;

    [Tooltip("The names of the audio")]
    public string giveUpHub;
    AudioPiece[] giveUpAudio;

    [Tooltip("The name of the hub holding the respawn quotes")]
    public string respawnHub;
    AudioPiece[] respawnAudio;

    [Tooltip("The chance that the roaming sound will play")]
    [Range(0, 100)]
    public float roamSoundChance;
    [Tooltip("The narration to play when the monster starts chasing you")]
    public string chaseNarratorHub;
    AudioPiece[] chaseNarrator;
    
    [Header("Animation Settings")]

    public float animSpeed = 1.5f;
    
    private NavMeshAgent agent; //The navmesh agent
    private Vector3 startingPos; //Starting position of the AI
    private Vector3 waypointLocation; //Waypoint the AI is travelling to
    private Coroutine sftCoroutine; //Holds the SearchingForPlayer coroutine
    private bool ranOnce; //Makes sure the coroutine is run once only
    
    //AI STATES
    public enum State
    {
        Roaming,
        SearchForTarget,
        ChaseTarget,
    }

    [HideInInspector]
    public State state;

    private State oldState;

    /// <summary>
    ///     Setting everything up that is needed
    /// </summary>
    public void Awake()
    {
        
        searchAudio = monsterManager.GetHub(searchHub);
        roamAudio = monsterManager.GetHub(roamHub);
        chaseAudio = monsterManager.GetHub(chaseHub);
        giveUpAudio = monsterManager.GetHub(giveUpHub);
        chaseNarrator = narratorManager.GetHub(chaseNarratorHub);
        respawnAudio = narratorManager.GetHub(respawnHub);

        agent = GetComponent<NavMeshAgent>();

        state = State.Roaming;

        startingPos = transform.position;

        waypointLocation = GetRandomWaypoint();
    }

    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude); //Sets the speed for the animator

        oldState = state; //DEBUG

        //Start of the switch statement
        switch(state)
        {
            default:

            //ROAMING
            case State.Roaming:

                agent.isStopped = false; //Allows for the AI to move

                agent.SetDestination(waypointLocation); //Move towards waypointLocation

                //Play roam sound if chances are successful
                //if (UnityEngine.Random.Range(0,100) < roamSoundChance)
                //{
                //    monsterManager.Play(roamAudio[Random.Range(0, roamAudio.Length)]);
                //}

                if (Vector3.Distance(transform.position, waypointLocation) < changeWaypointDistance) //If AI gets closer than changeWaypointDistance
                {
                    waypointLocation = GetRandomWaypoint();
                }

                FindTarget(); //Check how close the player is to the AI

                break;


            //SEARCH FOR TARGET
            case State.SearchForTarget:

                agent.isStopped = true; //Stop the AI in it's tracks
                
                //Only run the Coroutine once for searching for player
                if (!ranOnce)
                {
                    sftCoroutine = StartCoroutine(SearchingForPlayer(searchingTime));
                    ranOnce = true;
                }

                RaycastHit raycastHit;

                //TO DO Rotation using Unity MAYBE

                //Fire a Raycast towards the player and try to find them
                if (Physics.Raycast(transform.position, transform.TransformDirection(transform.forward), out raycastHit, monsterViewDistance))
                {
                    Debug.DrawLine(transform.position, transform.TransformDirection(transform.forward) * monsterViewDistance, Color.red);

                    if (raycastHit.collider.CompareTag("Player"))
                    {
                        state = State.ChaseTarget;
                    }
                }

                break;

            //CHASE TARGET
            case State.ChaseTarget:

                //Allows for the AI to move
                agent.isStopped = false;

                agent.SetDestination(player.transform.position); //Go towards the player

                if (Vector3.Distance(transform.position, player.transform.position) > maxChaseDistance)
                {
                    monsterManager.Play(searchAudio[Random.Range(0, searchAudio.Length)]);

                    //CHANGE STATE
                    state = State.SearchForTarget;
                    
                }
                break;
        }


        //DEBUG
        if (oldState != state)
        {
            Debug.LogWarning($"STATE CHANGED FROM {oldState} TO {state}");
        }
    }

    /// <summary>
    ///     Gets a random point from the WaypointData
    /// </summary>
    /// <returns>Random Waypoint from WaypointData</returns>
    Vector3 GetRandomWaypoint()
    {
        return waypoints.GetPointRandom();
    }

    /// <summary>
    ///     Shows how close the current GameObject is to the player GameObject
    /// </summary>
    private void FindTarget()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < searchForTargetRange)
        {
            monsterManager.Play(searchAudio[Random.Range(0, searchAudio.Length)]);
        }

        RaycastHit raycastHit;

        //Fire a linecast and try to find the player
        if (Physics.Linecast(transform.position, player.transform.position, out raycastHit))
        {
            Debug.DrawLine(transform.position, player.transform.position, Color.blue);

            if (raycastHit.collider.gameObject.CompareTag("Player"))
            {
                state = State.SearchForTarget;
            }
        }
        
    }
    /// <summary>
    ///     Searches for the player for a certain amount of time then changes state to Roaming
    /// </summary>
    /// <returns></returns>
    public IEnumerator SearchingForPlayer(float searchingTime)
    {
        //TODO Movement in local area potentially
        float time = 0;

        Vector3 targetHeading = player.transform.position - transform.position;
        Vector3 targetDirection = targetHeading.normalized;

        while (time < searchingTime)
        {
            //Everything that the AI does when searching goes here
            time += Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime);

            //If player gets too close to the AI when it's in search mode
            if (Vector3.Distance(transform.position, player.transform.position) < chaseTargetRange)
            {
                monsterManager.Play(chaseAudio[Random.Range(0, chaseAudio.Length)]);

                narratorManager.Play(chaseNarrator[Random.Range(0, chaseNarrator.Length)]);

                state = State.ChaseTarget;
                ranOnce = false;
                break;
            }
            yield return null;
        }

        //If player is still within it's radius when time is up then AI chases player
        if (Vector3.Distance(transform.position, player.transform.position) < searchForTargetRange)
        {
            monsterManager.Play(chaseAudio[Random.Range(0, chaseAudio.Length)]);

            state = State.ChaseTarget;
        }
        //Roam otherwise
        else
        {
            monsterManager.Play(giveUpAudio[Random.Range(0, giveUpAudio.Length)]);


            state = State.Roaming;
        }
        ranOnce = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = waypoints.GetPointRandom();
            narratorManager.Play(narratorManager.GetRandomPiece(respawnAudio));
        }
    }
}
