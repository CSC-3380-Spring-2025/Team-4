using UnityEngine;

public class HeavyEnemyDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damage = 15;                  // Moderate damage
    public float knockbackDistance = 6f;     // Mild knockback
    public float enemyRecoilDistance = 1f;   // Slight enemy bounce-back

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Vector2 contactPoint = collision.GetContact(0).point;

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamageWithKnockback(damage, contactPoint, knockbackDistance);
        }

        EnemyAI ai = GetComponent<EnemyAI>();
        if (ai != null)
        {
            ai.RecoilFromContact(contactPoint, enemyRecoilDistance);
        }
    }
}
