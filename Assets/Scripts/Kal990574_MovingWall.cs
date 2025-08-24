using UnityEngine;

public class Kal990574_MovingWall : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f; 

    private Vector3 startPos;
    private Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        Vector3 newPos = new Vector3(startPos.x + offset, startPos.y, startPos.z);
        rb.MovePosition(newPos); 
    }
}
