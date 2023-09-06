using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestAI_Nav : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject objective;
    [SerializeField] private GameObject spawner;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spawner = GameObject.Find("spawn1");

        agent.Warp(spawner.transform.position);
    }

    private void Update()
    {
        if(agent != null)
        {
            TestMovement();
        }
    }

    private void TestMovement()
    {
        agent.SetDestination(objective.transform.position);
    }
}
