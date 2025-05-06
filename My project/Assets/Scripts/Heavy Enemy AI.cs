using UnityEngine;
using System.Collections;

public class HeavyEnemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float detectionRange = 5f;

    public Transform pointA;
    public Transform pointB;
    public Transform player;

    private Vector3 currentTarget;
    private Rigidbody2D rb;
    private bool chasingPlayer = false;
    private SpriteRenderer spriteRenderer;

    private bool isKnockedBack = false;
    private float knockbackTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (isKnockedBack) return;

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
        rb.linearVelocity = new Vector2(direction.x * patrolSpeed, rb.linearVelocity.y);
        FlipSprite(direction.x);

        if (Vector2.Distance(transform.position, currentTarget) < 0.1f)
        {
            currentTarget = currentTarget == pointA.position ? pointB.position : pointA.position;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * chaseSpeed, rb.linearVelocity.y);
        FlipSprite(direction.x);
    }

    void FlipSprite(float moveX)
    {
    if (Mathf.Abs(moveX) > 0.05f)
    {
        Vector3 scale = transform.localScale;
        scale.x = moveX > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
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
