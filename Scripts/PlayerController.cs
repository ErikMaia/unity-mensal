using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float mouseSensitivity = 200f;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("References")]
    public Transform playerBody; // Reference to the player's body (for rotating around Y-axis)
    public PlayerScriptableObject playerScriptableObject;
    public Transform playerCamera; // Reference to the camera (for rotating around X-axis)
    private float xRotation = 0f; // Tracks vertical rotation to clamp camera

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "UTF"){
            transform.position = playerScriptableObject.position;
        }
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        Jump();
    }
    private void Jump(){
        var rb = GetComponent<Rigidbody>();
        if(rb != null && Input.GetKey(KeyCode.Space)){
            rb.AddForce(transform.up*5.0f);
        }
    }
    private void HandleMouseLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player body around the Y-axis
        playerBody.Rotate(Vector3.up * mouseX);

        // Adjust the vertical rotation of the camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit rotation to avoid flipping
        // Apply the rotation to the camera
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void HandleMovement()
    {
        // Get input from WASD keys
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Calculate movement direction relative to player's orientation
        Vector3 move = playerBody.forward * moveZ + playerBody.right * moveX;

        // Apply movement
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}