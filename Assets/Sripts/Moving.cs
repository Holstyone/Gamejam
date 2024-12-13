using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Update()
    {


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * vertical + right * horizontal).normalized;

        if (movement.magnitude > 0)
        {
            MovePlayer(movement);
        }


        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void MovePlayer(Vector3 movementDirection)
    {
        Vector3 newPosition = rb.position + movementDirection * speed * Time.deltaTime;
        rb.MovePosition(newPosition);

        Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
        rb.rotation = targetRotation;
    }

    void Jump()
    {
        Debug.Log("Spacja");
        if (isGrounded)
        {
            Debug.Log("Funkcja");
            rb.AddForce(0, jumpHeight, 0);
        }
    }

    void FixedUpdate()
    {

        if (!isGrounded)
        {
            rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        }
    }
}