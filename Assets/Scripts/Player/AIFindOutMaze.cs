using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIFindOutMaze : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField]
    public NavMeshPath path;

    public GameObject end;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(end.transform.position);
        agent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(agent.velocity);
    }
}
