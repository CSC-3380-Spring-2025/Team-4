using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;                // Drag the Player here in Inspector
    public float speedEnemy = 2f;
    public float chaseDistance = 5f;
    public float stopDistance = 0.5f;

    public SpriteRenderer spriteRenderer;   // Drag the child SpriteRenderer here

    private Vector2 startPos;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned.");
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not assigned.");
        }

        startPos = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        float distToPlayer = Vector2.Distance(transform.position, player.position);

        // Decide whether to chase the player or return to original position
        Vector2 targetPosition = distToPlayer < chaseDistance ? player.position : startPos;

        Vector2 direction = targetPosition - (Vector2)transform.position;

        // Flip sprite if direction is not too small
        if (spriteRenderer != null && Mathf.Abs(direction.x) > 0.01f)
        {
            spriteRenderer.flipX = direction.x > 0;
        }

        // Only move if far enough away
        if (direction.magnitude > stopDistance)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                speedEnemy * Time.deltaTime
            );
        }
    }
}
