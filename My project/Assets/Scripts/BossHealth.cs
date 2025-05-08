using UnityEngine;

public class BossHealth : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
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
        gameManager.AddPoints(1000);
        Destroy(gameObject);
    }
    
}
