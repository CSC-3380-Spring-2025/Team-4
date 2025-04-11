using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 2f;
    private int patrolDestination = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer == null)
        Debug.LogWarning(name + " is missing a SpriteRenderer in children!");
    }

    void Update()
    {
        Transform targetPoint = patrolPoints[patrolDestination];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        float distance = Vector2.Distance((Vector2)transform.position, (Vector2)targetPoint.position);
        if (distance < 0.5f)
        {
            patrolDestination = (patrolDestination + 1) % patrolPoints.Length;
        }

        Vector2 direction = targetPoint.position - transform.position;
        if (direction.x != 0)
        {
            spriteRenderer.flipX = direction.x > 0;
        }
    }
}
