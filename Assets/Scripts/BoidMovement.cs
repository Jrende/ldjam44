using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoidMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 target;
    GameObject[] hands;
    float avoidDist = 4f;
    float calmDist = 5f;
    float panicSpeed = 10.0f;
    float wanderSpeed = 1.5f;
    Random rnd = new Random();

    enum State { Panic, Wander };
    State currentState = State.Wander;

    void Start()
    {
        hands = GameObject.FindGameObjectsWithTag("hand");
        agent = GetComponentInChildren<NavMeshAgent>();

        target = getRandomPosition();
        
        //agent.destination = target;
    }


    void Update()
    {
        //agent.destination = target.position;
        Vector3 closestHand = getClosestHandPosition();
        //Debug.Log("Closest hand pos: " + closestHand);
        float handDist = Vector3.Distance(transform.position, closestHand);
        if (handDist < avoidDist)
        {
            Debug.Log("Avoid the hand!!");
            target = transform.position + (transform.position - closestHand).normalized * calmDist;
            Debug.DrawLine(target, target + Vector3.up);
            agent.destination = target;
            agent.speed = panicSpeed;
            agent.acceleration = 15f;
            currentState = State.Panic;
        }
        if (handDist > calmDist && currentState == State.Panic)
        {
            Debug.Log("All's chill again");
            currentState = State.Wander;
            agent.speed = wanderSpeed;
            agent.acceleration = 8f;
        }
        if (currentState == State.Wander)
        {
            
            float distToTarget = Vector3.Distance(transform.position, target);
            Debug.Log("target " + target);
            Debug.Log("dist " + distToTarget);
            if (distToTarget < 2.0f)
            {
                target = getRandomPosition();
                Debug.Log("Arrive! Got to" + target);
            }
            agent.destination = target;
        }
        Debug.DrawLine(transform.transform.position, target);
    }

    Vector3 getRandomPosition()
    {
        return transform.position + new Vector3(
            Random.Range(-1.0f, 1.0f),
            0,
            Random.Range(-1.0f, 1.0f)).normalized * Random.Range(2.0f, 6.0f);
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
