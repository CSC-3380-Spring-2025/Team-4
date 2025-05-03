using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

    public int maxHealth = 10;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Boss took damage! Current HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss defeated!");
        Destroy(gameObject); // You can trigger animations or events here instead
    }
}
