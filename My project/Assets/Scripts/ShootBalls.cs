using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public Transform player;

    public float attackRange = 7f;
    public float fireballSpeed = 5f;
    public float attackCooldown = 2f;
    private float attackTimer = 0f;

    void Update()
    {
        if (player == null) 
        {
            return;
        }

        attackTimer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attackRange && attackTimer >= attackCooldown)
        {
            Attack();
            attackTimer = 0f;
        }
    }

    void Attack()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

        Vector2 direction = (player.position - firePoint.position).normalized;

        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * fireballSpeed;
        }
    }
    
}
