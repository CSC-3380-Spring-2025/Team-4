using UnityEngine;

public class Fireball : MonoBehaviour
{

    private float lifetime = 5f;
    private int damage = 1;

    private Collider2D myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        Destroy(gameObject, lifetime);
    }

    public void IgnoreCollider(Collider2D col)
    {
        if (myCollider != null && col != null)
        {
            Physics2D.IgnoreCollision(myCollider, col);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamageWithKnockback(damage, transform.right, 2.5f);
            }

            Destroy(gameObject);
        }
        else if (!collision.isTrigger)
        {
            Destroy(gameObject);
        }
    }
    
}
