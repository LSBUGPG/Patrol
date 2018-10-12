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
			SendMessage("Investigate");
		}
		else if (vision.rangeToTarget > attackRange)
		{
			SendMessage("Chase");
		}
		else
		{
			enabled = false;
			SendMessage("Attack");
		}
	}
}
