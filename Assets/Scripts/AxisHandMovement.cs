using UnityEngine;
using UnityEngine.AI;

public class AxisHandMovement : MonoBehaviour
{
    public int index;
    //private Transform transform;
    private float speed = 5;

    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        //rigidBody = GetComponent<Rigidbody>();
        //transform = GetComponent<Transform>();            
    }

    void Update()
    {
        float horiz = Input.GetAxis("Horizontal" + index) / speed;
        float vert = Input.GetAxis("Vertical" + index) / speed;

        transform.position += new Vector3(-horiz, 0, vert);
    }
}
