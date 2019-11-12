using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Investigate : MonoBehaviour
{
    Vision vision;
    NavMeshAgent agent;

    void Awake()
    {
        vision = GetComponent<Vision>();
        agent = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        agent.SetDestination(vision.lastKnownPosition);
    }

    void Update()
    {
        if (!agent.hasPath)
        {
            SendMessage("SetBehaviour", "Patrol");
        }
    }
}