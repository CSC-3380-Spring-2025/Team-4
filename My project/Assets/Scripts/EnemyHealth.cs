using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;

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
        gameManager.AddPoints(10);
        Destroy(gameObject);
    }
}

