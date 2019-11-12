using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackRange;
    Vision vision;

    void Awake()
    {
        vision = GetComponent<Vision>();
    }

    void Update()
    {
        if (vision.target == null)
        {
            SendMessage("SetBehaviour", "Investigate");
        }
        else if (vision.rangeToTarget > attackRange)
        {
            SendMessage("SetBehaviour", "Chase");
        }
        else
        {
            Debug.Log("Attack");
        }
    }
}