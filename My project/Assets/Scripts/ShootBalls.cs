using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject fireballPrefab;      // Assign your fireball prefab here
    public Transform firePoint;            // Where the fireball spawns from
    public Transform player;               // Reference to the player
    public float attackRange = 7f;         // How close the player needs to be
    public float fireballSpeed = 5f;       // Speed of the fireball
    public float attackCooldown = 2f;      // Time between attacks

    private float attackTimer = 0f;

    void Update()
    {
        if (player == null) return;

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
        // Create the fireball
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

        // Calculate direction toward the player
        Vector2 direction = (player.position - firePoint.position).normalized;

        // Set the velocity
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * fireballSpeed;
        }
    }
}
