using UnityEngine;

public class EnemyChase : MonoBehaviour
{

    public Transform playerTransform;
    public float moveSpeed = 2f;
    public float chaseRange = 5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer == null)
        {
           Debug.LogWarning(name + " is missing a SpriteRenderer in children!");
        }
    }

    void Update()
    {
        if (playerTransform == null) 
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, playerTransform.position);

        if (distance < chaseRange)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

            if (direction.x != 0)
            {
               spriteRenderer.flipX = direction.x > 0;
            }
        }
    }

}
