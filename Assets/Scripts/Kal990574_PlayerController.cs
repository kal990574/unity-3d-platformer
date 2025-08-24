using UnityEngine;

public class Kal990574_PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded = false;
    public static Vector3 cameraFollowPos;
    private Kal990574_GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameManager = FindAnyObjectByType<Kal990574_GameManager>();
    }

    void Update()
    {
        if (transform.position.y < -10f && gameManager != null)
        {
            gameManager.GameOver();
        }
        // 점프 입력
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
{
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    Vector3 move = Vector3.zero;
    if (Camera.main != null)
    {
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();
        move = (camForward * v + camRight * h).normalized;
    }
        if (move.magnitude < 0.1f)
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }
        else
        {
            Vector3 targetVelocity = move * moveSpeed;
            Vector3 velocityChange = targetVelocity - rb.linearVelocity;
            velocityChange.y = 0f;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
}

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.4f)
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            if (gameManager != null)
            {
                gameManager.GameClear();
            }
        }
    }
}