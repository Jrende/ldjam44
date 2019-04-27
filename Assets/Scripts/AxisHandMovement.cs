using UnityEngine;
using UnityEngine.AI;

public class AxisHandMovement : MonoBehaviour
{
    public int index;
    //private Transform transform;

    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        //rigidBody = GetComponent<Rigidbody>();
        //transform = GetComponent<Transform>();            
    }

    void Update()
    {
        float horiz = Input.GetAxis("Horizontal" + index);
        float vert = Input.GetAxis("Vertical" + index);

        transform.position += new Vector3(horiz, 0, vert);
    }
}
