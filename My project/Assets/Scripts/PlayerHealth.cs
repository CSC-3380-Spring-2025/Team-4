using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthmeter;
    [SerializeField] GameManager gameManager;

    private float lastDamageTime = -Mathf.Infinity;
    public float damageCooldown = 1f;

    void Start()
    {
        if (maxHealth <= 0) maxHealth = health;
    }

    public void TakeDamageWithKnockback(int damage, Vector2 hitFromDirection, float distance)
    {
        if (Time.time - lastDamageTime < damageCooldown)
            return;

        lastDamageTime = Time.time;
        health -= damage;

        Vector2 knockbackDir = (transform.position - (Vector3)hitFromDirection).normalized;
        StartCoroutine(SmoothKnockback(knockbackDir, distance, 0.15f)); // Smooth for 0.15 seconds
    }

    private IEnumerator SmoothKnockback(Vector2 direction, float distance, float duration)
    {
        float elapsed = 0f;
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + (Vector3)(direction * distance);

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }

    void Update()
    {
        healthmeter.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HealthUp"))
        {
            maxHealth = health * 2;
            health = maxHealth;
            Destroy(collision.gameObject);
        }
    }
}
