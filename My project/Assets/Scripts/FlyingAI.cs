using UnityEngine;
using System.Collections;

public class FlyingEnemyAI : MonoBehaviour
{

    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float detectionRange = 7f;

    public Transform pointA;
    public Transform pointB;
    public Transform player;

    private Vector3 currentTarget;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    private bool chasingPlayer = false;

    private bool isKnockedBack = false;
    private float knockbackTimer = 0f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0f;
        spriteRenderer = transform.Find("Graphics")?.GetComponent<SpriteRenderer>();
        currentTarget = pointB.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        chasingPlayer = distanceToPlayer <= detectionRange;

        if (isKnockedBack)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0f)
            {
                isKnockedBack = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (isKnockedBack) {
            return;
        }

        if (chasingPlayer)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Vector2 direction = (currentTarget - transform.position).normalized;
        rigidBody.linearVelocity = direction * patrolSpeed;
        FlipSprite(direction.x);

        if (Vector2.Distance(transform.position, currentTarget) < 0.1f)
        {
            currentTarget = currentTarget == pointA.position ? pointB.position : pointA.position;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rigidBody.linearVelocity = direction * chaseSpeed;
        FlipSprite(direction.x);
    }

    void FlipSprite(float moveX)
    {
        if (spriteRenderer != null && Mathf.Abs(moveX) > 0.05f)
        {
            spriteRenderer.flipX = moveX > 0;
        }
    }

    public void RecoilFromContact(Vector2 hitFromDirection, float distance)
    {
        Vector2 knockbackDir = (transform.position - (Vector3)hitFromDirection).normalized;
        StartCoroutine(SmoothRecoil(knockbackDir, distance, 0.15f));
    }

    private IEnumerator SmoothRecoil(Vector2 direction, float distance, float duration)
    {
        isKnockedBack = true;
        knockbackTimer = duration;

        float elapsed = 0f;
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + (Vector3)(direction * distance);

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isKnockedBack = false;
    }
    
}
