using UnityEngine;

// Controls player movement without rotation and allows jumping.
public class PlayerController : MonoBehaviour
{
    public float speed;         // Forward/backward movement speed.
    public float strafeSpeed;   // Left/right movement speed.
    public float jumpForce;     // Upward force applied when jumping.

    private Rigidbody rb;             // Reference to the player's Rigidbody.
    private bool isGrounded = true;   // Flag to check if the player is on the ground.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen.
    }

    private void updateMovement()
    {
        // Get input for forward/backward and left/right movement.
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 velocity = Vector3.zero;

        // Calculate forward/backward movement.
        if (moveVertical != 0 || moveHorizontal != 0)
        {
            Vector3 direction = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized;
            velocity = direction * speed;
        }
        
        velocity.y = rb.linearVelocity.y; // Preserve the vertical velocity (gravity).
        rb.linearVelocity = velocity; // Apply the calculated velocity to the Rigidbody.
        
    }

    private void updateMouseLook()
    {
        // Get mouse input for looking around.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseX != 0)
        {
            transform.Rotate(0, mouseX * 3, 0);
        }

//        if (mouseY != 0)
 //       {
   //         Camera camera = GetComponentInChildren<Camera>();
     //       if (camera != null)
       ////       camera.transform.Rotate(-mouseY * 1, 0, 0);
           // }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // updateMovement();
        // updateMouseLook();

        // Handle jump input (only when grounded)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Handle physics-based movement.
    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = (transform.forward * moveVertical * speed + transform.right * moveHorizontal * strafeSpeed) * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    // Detect when player touches the ground to allow jumping again.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}



