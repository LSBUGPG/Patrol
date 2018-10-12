using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
	public List<Behaviour> states = new List<Behaviour>();

	void SetBehaviour(string behaviourName)
	{
		states.ForEach((behaviour) => behaviour.enabled = behaviour.GetType().ToString() == behaviourName);
	}

	void Chase()
	{
		SetBehaviour("Chase");
	}

	void Patrol()
	{
		SetBehaviour("Patrol");
	}

	void Investigate()
	{
		SetBehaviour("Investigate");
	}

	void Attack()
	{
		SetBehaviour("Attack");
	}
}
