using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Patrol : MonoBehaviour
{
    NavMeshAgent agent;
    WayPoint[] wayPoints;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        wayPoints = FindObjectsOfType<WayPoint>();
    }

    void OnEnable()
    {
        WayPoint wayPoint = wayPoints[Random.Range(0, wayPoints.Length)];
        agent.SetDestination(wayPoint.transform.position);
    }

    void Update()
    {
        if (!agent.hasPath)
        {
            enabled = false;
            SendMessage("SetBehaviour", "Patrol");
        }
    }
}