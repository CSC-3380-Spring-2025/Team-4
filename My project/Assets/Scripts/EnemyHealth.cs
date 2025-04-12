using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   public int health = 1;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Death animation, sound, etc.
        Destroy(gameObject);
    }
}

