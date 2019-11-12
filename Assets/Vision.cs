using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public float viewDistance = 10.0f;
    public float fov = 90.0f;
    Transform player;

    internal Transform target;
    internal float rangeToTarget;
    internal Vector3 lastKnownPosition;

    void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawFrustum(Vector3.zero, fov, viewDistance, 0.5f, 1.0f);
        Gizmos.DrawWireSphere(Vector3.zero, viewDistance);
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 toPlayer = player.transform.position - transform.position;
            float distance = toPlayer.magnitude;
            if (distance < viewDistance && Vector3.Angle(toPlayer, transform.forward) < 0.5f * fov)
            {
                rangeToTarget = distance;
                if (target == null)
                {
                    SendMessage("SetBehaviour", "Chase");
                }
                target = player.transform;
            }
            else
            {
                if (target != null)
                {
                    lastKnownPosition = target.transform.position;
                }
                target = null;
            }
        }
    }
}