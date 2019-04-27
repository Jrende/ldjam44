using UnityEngine;
using UnityEngine.AI;

public class HandMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public float distance = 50f;
    private Rigidbody rigidBody;
    //private Transform transform;
        
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        //rigidBody = GetComponent<Rigidbody>();
        //transform = GetComponent<Transform>();            
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            Vector3 v = hit.point;
            v.y = 0;
            //rigidBody.position = v;
            transform.position = v;

        }
    }
}
