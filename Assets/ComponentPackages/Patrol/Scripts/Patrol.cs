using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Patrol : MonoBehaviour
{
    public UnityEvent onWaypointReached;
    public WayPoint[] wayPoints;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
            onWaypointReached.Invoke();
        }
    }
}
