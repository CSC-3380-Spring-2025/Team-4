using UnityEngine;

public class CombatMode : MonoBehaviour
{
    [Header("Movement")]
    public float skateboardSpeed = 10f;
    public float combatSpeed = 4f;
    public float skateboardJumpForce = 12f;
    public float combatJumpForce = 4f;

    [Header("State")]
    public bool inCombatMode = false;
    public bool isDead = false;

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rb;
    private float currentSpeed;

    private bool isGrounded;
    private float cooldown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("Missing Rigidbody2D!");

        if (animator == null) animator = GetComponent<Animator>();
        if (animator == null) Debug.LogWarning("Missing Animator!");

        currentSpeed = skateboardSpeed;
    }

    void Update()
    {
        if (isDead)
        {
            HandleDeath();
            return;
        }

        HandlePauseInput();

        if (GameManager.isPaused) return;

        HandleModeSwitch();
        HandleAttack();
        HandleJump();
        //HandleAnimatorInput();
        Move();

        if (transform.position.y < -12f) Die();
    }

    private void HandlePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.isPaused) gameManager.ResumeGame();
            else gameManager.PauseGame();
        }
    }

    private void HandleModeSwitch()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            inCombatMode = !inCombatMode;
            currentSpeed = inCombatMode ? combatSpeed : skateboardSpeed;
            Debug.Log("Combat Mode: " + inCombatMode);
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            float jumpForce = inCombatMode ? combatJumpForce : skateboardJumpForce;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            Debug.Log("Jumped with force: " + jumpForce);
        }
    }

    private void HandleAttack()
    {
        if (inCombatMode && Input.GetKeyDown(KeyCode.Z))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1.0f);
            foreach (Collider2D hit in hits)
            {
                EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                    Debug.Log("Hit enemy!");
                }
            }
        }
    }

    private void HandleAnimatorInput()
    {
        float moveX = Input.GetAxis("Horizontal");

        animator?.SetBool("isRunning", moveX != 0);
        animator?.SetBool("isCached", true);
        animator?.SetBool("isPressed", false);

        if (Input.GetKeyDown(KeyCode.R))
        {
            animator?.SetBool("isSkateboarding", false);
            animator?.SetBool("isCached", false);
            animator?.SetBool("isPressed", true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            animator?.SetBool("isSkateboarding", true);
            animator?.SetBool("isCached", false);
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        Debug.Log("moveX: " + moveX); // Debug to check if input is detected
        rb.linearVelocity = new Vector2(moveX * currentSpeed, rb.linearVelocity.y);
    }

    public void Die()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        Destroy(gameObject);
        gameManager.GameOver();
    }

    private void HandleDeath()
    {
        DestroyImmediate(rb);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Grounded!");
        }

        if (collision.gameObject.CompareTag("SpeedUp"))
        {
            SpeedUp(collision);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void SpeedUp(Collision2D collision)
    {
        cooldown = Time.time + 5f;
        skateboardSpeed = 30f;
        Destroy(collision.gameObject);
    }
}
