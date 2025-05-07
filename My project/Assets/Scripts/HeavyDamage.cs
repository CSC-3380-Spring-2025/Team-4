using UnityEngine;

public class HeavyEnemyDamage : MonoBehaviour
{

    [Header("Damage Settings")]
    public int damage = 15;
    public float knockbackDistance = 6f; 
    public float enemyRecoilDistance = 1f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) 
        {
            return;
        }
        
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
