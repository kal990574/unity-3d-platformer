using UnityEngine;

public class Kal990574_Trampoline : MonoBehaviour
{
   public float bounceForce = 15f;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null && other.CompareTag("Player"))
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.y = 0f;
            rb.linearVelocity = velocity;

            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}
