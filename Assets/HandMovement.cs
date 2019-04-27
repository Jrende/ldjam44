using UnityEngine;
using UnityEngine.AI;

public class HandMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public float distance = 50f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            agent.destination = hit.point;
        }
    }
}
