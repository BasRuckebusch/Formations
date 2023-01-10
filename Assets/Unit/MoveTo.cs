using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

	[SerializeField] private Transform goal;
	private NavMeshAgent agent;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		agent.destination = goal.position;
	}
}
