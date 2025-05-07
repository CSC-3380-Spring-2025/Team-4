using UnityEngine;

public class MonsterDamage : MonoBehaviour
{

    private int damage = 2;
    private float knockbackDistance = 1.5f;
    private float enemyRecoilDistance = 1.5f;

    [HideInInspector] public bool hasBeenStomped = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (hasBeenStomped)
        {
            return;
        } 

        if (collision.collider.CompareTag("EnemyHead")) 
        {
            return;
        }

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
