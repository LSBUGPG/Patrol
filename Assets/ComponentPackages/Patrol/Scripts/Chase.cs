using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Chase : MonoBehaviour
{
    public float attackRange = 2.0f;
    public UnityEvent inRange;
    public UnityEvent targetLost;
    NavMeshAgent agent;
    Vision vision;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        vision = GetComponent<Vision>();
    }

    void Update()
    {
        if (vision.target != null)
        {
            if (vision.rangeToTarget < attackRange)
            {
                inRange.Invoke();
            }
            else
            {
                agent.SetDestination(vision.target.position);
            }
        }
        else
        {
            targetLost.Invoke();
        }
    }
}
