using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoidMovement : MonoBehaviour
{
    public GameObject palm;
    private NavMeshAgent agent;
    public Transform target;

    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
    }

    
    void Update() {
        agent.destination = target.position;
    }
}
