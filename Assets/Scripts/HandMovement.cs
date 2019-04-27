using UnityEngine;
using UnityEngine.AI;

public class HandMovement : MonoBehaviour
{
    private Plane groundPlane;
    public GameObject planeGameObject;
    
    void Start()
    {
        groundPlane = new Plane(planeGameObject.transform.up, planeGameObject.transform.position);
    }

    void Update() { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            
            Vector3 v = ray.GetPoint(rayDistance);
            //Debug.DrawLine(hit.point, hit.point * 2, new Color(1.0f, 1.0f, 1.0f));
            //v.y = 0;
            //rigidBody.position = v;
            transform.position = v;

        }
    }
}
