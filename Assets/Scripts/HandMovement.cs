using UnityEngine;
using UnityEngine.AI;

public class HandMovement : MonoBehaviour
{
    private Plane groundPlane;
    public GameObject planeGameObject;
    private Vector3 target;
    private NavMeshAgent mrSmith;
    
    void Start()
    {
        groundPlane = new Plane(planeGameObject.transform.up, planeGameObject.transform.position);
        mrSmith = GetComponent<NavMeshAgent>();
    }

    void Update() { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 v = ray.GetPoint(rayDistance);
            target = v;
            mrSmith.destination = v;
            Debug.DrawLine(transform.position, v, new Color(1.0f, 0.0f, 0.0f));
        }
    }
}
