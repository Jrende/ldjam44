using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoidMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 target;
    GameObject[] hands;
    float avoidDist = 2f;

    void Start()
    {
        hands = GameObject.FindGameObjectsWithTag("hand");
        agent = GetComponentInChildren<NavMeshAgent>();
        //agent.destination = target;
    }


    void Update()
    {
        //agent.destination = target.position;
        Vector3 closestHand = getClosestHandPosition();
        //Debug.Log("Closest hand pos: " + closestHand);
        float dist = Vector3.Distance(transform.position, closestHand);
        Debug.Log("dist:" + dist);
        if (dist < avoidDist)
        {
            Debug.Log("Avoid the hand!!");
            target = (transform.position - closestHand).normalized * avoidDist;
            Debug.Log("Go to " + target);
            Debug.DrawLine(target, target + Vector3.up);
            agent.destination = target;
        }
    }

    Vector3 getClosestHandPosition()
    {
        double minDist = 1000000;
        Transform selectedTransform = null;
        foreach (GameObject hand in hands)
        {
            float dist = Vector3.Distance(hand.transform.position, transform.position);
            if (minDist > dist)
            {
                selectedTransform = hand.transform;
                minDist = dist;
            }
        }
        return selectedTransform.position;
    }
}
