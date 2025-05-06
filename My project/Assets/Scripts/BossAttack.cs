using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public Transform player;
    public float attackRange = 7f;
    public float fireballSpeed = 5f;

    public float normalAttackCooldown = 2f;
    public float fastAttackCooldown = 1f;
    public int normalFireballCount = 1;
    public int fastFireballCount = 3;
    public float spreadAngle = 30f; // Angle range for multiple fireballs

    private float attackTimer = 0f;
    private BossPatrol bossPatrol;

    void Start()
    {
        bossPatrol = GetComponent<BossPatrol>();
        if (bossPatrol == null)
        {
            Debug.LogWarning("BossAttack could not find BossPatrol on the same GameObject.");
        }
    }

    void Update()
    {
        if (player == null || bossPatrol == null) return;

        attackTimer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attackRange)
        {
            float cooldown = bossPatrol.IsSpeedingUp() ? fastAttackCooldown : normalAttackCooldown;
            if (attackTimer >= cooldown)
            {
                Attack();
                attackTimer = 0f;
            }
        }
    }

    void Attack()

    {
        Debug.Log("Boss is attacking!");

        int fireballCount = bossPatrol.IsSpeedingUp() ? fastFireballCount : normalFireballCount;

        if (fireballCount == 1)
        {
            ShootFireball((player.position - firePoint.position).normalized);
        }
        else
        {
            float angleStep = spreadAngle / (fireballCount - 1);
            float startAngle = -spreadAngle / 2;

            for (int i = 0; i < fireballCount; i++)
            {
                float angle = startAngle + i * angleStep;
                Vector2 direction = Quaternion.Euler(0, 0, angle) * (player.position - firePoint.position).normalized;
                ShootFireball(direction);
            }
        }
    }

    void ShootFireball(Vector2 direction)
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        fireball.transform.localScale *= 2f;
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * fireballSpeed;
        }
    }
}
