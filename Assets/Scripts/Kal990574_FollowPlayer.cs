using UnityEngine;

public class Kal990574_FollowPlayer : MonoBehaviour
{
    public Transform target;          
    public Vector3 offset = new Vector3(0, 5, -7);
    public float smoothSpeed = 0.15f;      
    public float mouseSensitivity = 3f;    
    public float minYAngle = -30f;        
    public float maxYAngle = 60f;

    private float yaw;           
    private float pitch;       

    void Start()
    {
        yaw = 0f;
        pitch = 20f;
        if (target != null)
        {
            yaw = target.eulerAngles.y;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minYAngle, maxYAngle);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 desiredPosition = target.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target.position + Vector3.up * 1.5f); 
    }
}
