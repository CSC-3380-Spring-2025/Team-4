using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float speed = 5f;       // Movement speed
    public float jumpForce = 12f;  // Jump strength
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private Animator animator;
    [SerializeField] GameManager gameManager;
    public bool isDead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead)
        {
            DestroyImmediate(rb);
            return;
        }
        // Get left/right input (A/D or Left/Right Arrow)
        float moveX = Input.GetAxis("Horizontal");

        // Apply horizontal movement
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
        animator.SetBool("isCached",true);
        if(moveX != 0){
            animator.SetBool("isRunning",true);
        }
        else{
             animator.SetBool("isRunning",false);
        }
        // Jumping (Space key)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; // Prevent multiple jumps
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
             animator.SetBool("isSkateboarding",false);
             animator.SetBool("isCached",false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetBool("isSkateboarding",true);
            animator.SetBool("isCached",false);
        }

        if(!isDead && (transform.position.y < -12f))
        {
            Die();
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

    public void Die()
    {
        isDead = true;
        rb.linearVelocity = Vector3.zero;
        Destroy(gameObject);
        gameManager.GameOver();
    }
}