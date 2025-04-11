using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }
    void Update()
    {
        if(patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
            {
                //transform.localScale = new Vector2(-1, 1);
                patrolDestination = 1;
            }
        }
        if(patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
            {
                //transform.localScale = new Vector2(1, 1);
                patrolDestination = 0;
            }
        }
        Vector2 direction = patrolPoints[patrolDestination].position - transform.position;
        if (direction.x != 0)
        {
            spriteRenderer.flipX = direction.x > 0;
        }
    }
}
