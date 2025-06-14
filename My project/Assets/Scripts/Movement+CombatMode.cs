using UnityEngine;

public class CombatMode : MonoBehaviour
{

    [Header("Movement")]
    public float skateboardSpeed = 10f;
    public float combatSpeed = 4f;
    public float skateboardJumpForce = 20f;
    public float combatJumpForce = 4f;
    public Animator animator;

    [Header("Attack Components")]
    public GameObject attackPointRight;
    public GameObject attackPointLeft;
    private GameObject currentAttackPoint;
    public float radius;
    public LayerMask enemies;

    [Header("State")]
    public bool inCombatMode = false;
    public bool isDead = false;

    [Header("References")]
    [SerializeField] private GameManager gameManager;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float currentSpeed;
    private bool isGrounded;
    private float cooldown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) 
        {
            Debug.LogError("Missing Rigidbody2D!");
        }

        if (animator == null) 
        {
            animator = GetComponent<Animator>();
        }

        if (animator == null) 
        {
            Debug.LogWarning("Missing Animator!");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

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


        if (GameManager.isPaused) 
        {
            return;
        }

        HandleModeSwitch();
        HandleAttack();
        HandleJump();
        Move();

        if (transform.position.y < 36f) 
        {
            Die();
        }
    }

    private void HandlePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.isPaused) 
            {
                gameManager.ResumeGame();
            }
            else
            {
                gameManager.PauseGame();
            }
        }
    }

    private void HandleModeSwitch()
    {
        if (Input.GetKeyDown(KeyCode.X) && isGrounded)
        {
            inCombatMode = !inCombatMode;
            animator.SetBool("CombatModeOn", inCombatMode);
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
            animator.SetTrigger("Attack");
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
        Debug.Log("moveX: " + moveX);
        rb.linearVelocity = new Vector2(moveX * currentSpeed, rb.linearVelocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveX));

        if (moveX < 0)
        {
            spriteRenderer.flipX = true;
            currentAttackPoint = attackPointLeft;
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = false;
            currentAttackPoint = attackPointRight;
        }
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

    public void PerformAttack()
    {
        if (currentAttackPoint == null)
        {
            return;
        } 

        Collider2D[] hits = Physics2D.OverlapCircleAll(currentAttackPoint.transform.position, radius, enemies);
        foreach (Collider2D hit in hits)
        {
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
                Debug.Log("Hit enemy: " + hit.name);
                gameManager.AddPoints(10);
            }
        }
    }
   
}
