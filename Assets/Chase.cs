using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
	public float attackRange = 2.0f;
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
				SendMessage("Attack");
			}
			else
			{
				agent.SetDestination(vision.target.position);
			}
		}
		else
		{
			SendMessage("Investigate");
		}
	}
}
