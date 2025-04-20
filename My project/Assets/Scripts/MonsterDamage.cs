using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage = 2;
    public float knockbackDistance = 1.5f;
    public float enemyRecoilDistance = 1.5f;

    [HideInInspector] public bool hasBeenStomped = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (hasBeenStomped) return; // 🛡 Skip if stomped

        if (collision.collider.CompareTag("EnemyHead")) return;

        if (collision.gameObject.CompareTag("Player"))
        {
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
}
