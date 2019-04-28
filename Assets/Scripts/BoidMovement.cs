using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoidMovement : MonoBehaviour
{
    public GameObject victoryArea;
    private NavMeshAgent agent;
    private Vector3 target;
    GameObject[] hands;
    float avoidDist = 4f;
    float calmDist = 5f;
    float panicSpeed = 10.0f;
    float wanderSpeed = 1.5f;
    Random rnd = new Random();

    enum State { Panic, Wander, Caught };
    State currentState = State.Wander;

    void Start()
    {
        hands = GameObject.FindGameObjectsWithTag("hand");
        agent = GetComponentInChildren<NavMeshAgent>();
        target = getRandomPosition();
    }

    void Update()
    {
        //agent.destination = target.position;
        Vector3 closestHand = getClosestHandPosition();
        //Debug.Log("Closest hand pos: " + closestHand);
        float handDist = Vector3.Distance(transform.position, closestHand);

        if (handDist < avoidDist && currentState != State.Caught)
        {
            target = transform.position + (transform.position - closestHand).normalized * calmDist;
            Debug.DrawLine(target, target + Vector3.up);
            agent.destination = target;
            agent.speed = panicSpeed;
            agent.acceleration = 15f;
            currentState = State.Panic;
        }

        if (handDist > calmDist && currentState == State.Panic)
        {
            currentState = State.Wander;
            target = getRandomPosition();
            agent.speed = wanderSpeed;
            agent.acceleration = 8f;
        }

        if (currentState == State.Wander)
        {
            float distToTarget = Vector3.Distance(transform.position, target);
            if (distToTarget < 2.0f)
            {
                target = getRandomPosition();
            }
            agent.destination = target;
        }
        if (currentState == State.Caught)
        {
            float distToTarget = Vector3.Distance(transform.position, target);
            //Debug.Log("dist " + distToTarget);
            if (distToTarget < 1.0f)
            {
                target = getRandomPositionInVictoryArea();
                //Debug.Log("Go to new area in vic");
            }
            agent.destination = target;
        }

        Debug.DrawLine(transform.transform.position, target, getStateColor());
    }

    private Color getStateColor()
    {
        if (currentState == State.Panic)
        {
            return Color.red;
        } else if (currentState == State.Wander)
        {
            return Color.green;
        } else if (currentState == State.Caught)
        {
            return Color.blue;
        }
        return Color.white;
    }

    public void catchBoid()
    {
        Vector3 t = getRandomPositionInVictoryArea();
        currentState = State.Caught;
        agent.speed = 2;
        agent.velocity = t.normalized;
        //agent.acceleration = 1;
        target = t;
    }

    Vector3 getRandomPosition()
    {
        Vector3 newTarget;
        NavMeshHit hit;
        do
        {
            newTarget = transform.position + new Vector3(
                Random.Range(-1.0f, 1.0f),
                0,
                Random.Range(-1.0f, 1.0f)).normalized * Random.Range(2.0f, 6.0f);
        } while (NavMesh.Raycast(transform.position, newTarget, out hit, NavMesh.AllAreas));
        return newTarget;
    }

    Vector3 getRandomPositionInVictoryArea()
    {
        Debug.Log("getRandomPositionInVictoryArea");
        
        
        
        Vector3 newTarget = transform.position + new Vector3(
                Random.Range(-1.0f, 1.0f),
                0,
                Random.Range(-1.0f, 1.0f)).normalized * Random.Range(0.5f, 3.0f);
        NavMeshHit hit;
        int navMeshArea = 1 << NavMesh.GetAreaFromName("Victory");
        NavMesh.SamplePosition(newTarget, out hit, 5, navMeshArea);
        Debug.Log("navMeshArea " + navMeshArea);
       
        return hit.position;
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
