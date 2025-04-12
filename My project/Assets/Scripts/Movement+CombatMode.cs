using Unity.VisualScripting;
using UnityEngine;

public class CombatMode : MonoBehaviour
{

    public float skateboardSpeed = 10f;
    public float combatSpeed = 4f;
    public float skateboardjumpForce = 12f;
    public float combatjumpForce = 4f;
    public bool inCombatMode = false;
    private bool isGrounded;
    private float cooldowntimer;
    [SerializeField] private Animator animator;
    [SerializeField] GameManager gameManager;

    private float currentSpeed;
    private Rigidbody2D rb;
    public bool isDead = false;
    private float cooldown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentSpeed = skateboardSpeed;
    }

    void Update()
    {
        if(isDead)
        {
            DestroyImmediate(rb);
            return;
        }

        if (!isDead && Input.GetKeyDown(KeyCode.Escape))
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

        if (GameManager.isPaused)
        {
            return;
        }

        

        if (Input.GetKeyDown(KeyCode.X))
        {
            inCombatMode = !inCombatMode;
            currentSpeed = inCombatMode ? combatSpeed : skateboardSpeed;
        }

        Move();
        if (inCombatMode && Input.GetKeyDown(KeyCode.Z)) // Attack button
        {
            Attack();
        }
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);
        float moveX = Input.GetAxis("Horizontal");

        animator.SetBool("isCached",true);
        animator.SetBool("isPressed",false);
        if(moveX != 0){
            animator.SetBool("isRunning",true);
        }
        else{
             animator.SetBool("isRunning",false);
        }

        // Jumping (Space key)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, skateboardjumpForce);
            isGrounded = false; // Prevent multiple jumps
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
             animator.SetBool("isSkateboarding",false);
             animator.SetBool("isCached",false);
             animator.SetBool("isPressed",true);
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


    public void Die()
    {
        isDead = true;
        rb.linearVelocity = Vector3.zero;
        Destroy(gameObject);
        gameManager.GameOver();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("SpeedUp"))
        {
            SpeedUp(collision);
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

    public void SpeedUp(Collision2D collision){
        cooldown = cooldowntimer;
        skateboardSpeed = 30;
        Destroy(collision.gameObject);
    }

    void Attack()
    {
    Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1.0f); // Adjust radius and layer
        foreach (Collider2D hit in hits)
        {
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
        
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
        
        }
    }
}
