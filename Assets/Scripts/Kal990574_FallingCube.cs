using UnityEngine;

public class Kal990574_FallingCube : MonoBehaviour
{
    public float delay = 0.5f;
    private bool isFalling = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = false; 
        rb.isKinematic = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            Invoke(nameof(EnableGravity), delay);
            isFalling = true;
        }
    }

    void EnableGravity()
    {
        rb.useGravity = true; 
    }
}
