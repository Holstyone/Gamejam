using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 100f;
    public float distanceFromPlayer = 0f;
    [SerializeField] GameObject Camera;

    private float pitch = 0f, yaw = 0f, bobbingTimer = 0f;
    private const float bobbingSpeed = 5f, bobbingAmount = 0.1f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch - Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime, -60f, 60f);

        player.rotation = Quaternion.Euler(0f, yaw, 0f);
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

        Vector3 pos = player.position - transform.forward * distanceFromPlayer;
        if (player.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
        {
            bobbingTimer += Time.deltaTime * bobbingSpeed;
        }
        Camera.transform.position = pos;
    }
}
