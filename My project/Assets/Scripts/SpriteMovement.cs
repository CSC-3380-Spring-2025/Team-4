using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float speed = 5f;       // Movement speed
    public float jumpForce = 12f;  // Jump strength
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
    }

    void Update()
    {
        // Get left/right input (A/D or Left/Right Arrow)
        float moveX = Input.GetAxis("Horizontal");

        // Apply horizontal movement
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        // Jumping (Space key)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; // Prevent multiple jumps
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Player is in the air
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}