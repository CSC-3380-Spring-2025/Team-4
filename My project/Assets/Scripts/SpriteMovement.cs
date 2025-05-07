using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;

    private Rigidbody2D rigidBody;

    private bool isGrounded;
    private float cooldowntimer;
    private float cooldown;

    [SerializeField] private Animator animator;
    [SerializeField] private GameManager gameManager;

    public bool isDead = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead)
        {
            DestroyImmediate(rigidBody);
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

        float moveX = Input.GetAxis("Horizontal");

        rigidBody.linearVelocity = new Vector2(moveX * speed, rigidBody.linearVelocity.y);
        animator.SetBool("isCached",true);
        animator.SetBool("isPressed",false);
        if (moveX != 0){
            animator.SetBool("isRunning",true);
        }
        else{
             animator.SetBool("isRunning",false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpForce);
            isGrounded = false;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Die()
    {
        isDead = true;
        rigidBody.linearVelocity = Vector3.zero;
        Destroy(gameObject);
        gameManager.GameOver();
    }

    public void SpeedUp(Collision2D collision){
        cooldown = cooldowntimer;
        speed = 30;
        Destroy(collision.gameObject);
    }

}
