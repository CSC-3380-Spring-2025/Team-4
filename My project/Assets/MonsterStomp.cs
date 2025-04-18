using UnityEngine;

public class MonsterStomp : MonoBehaviour
{
    public float bounceForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the "Players feet"
        if (collision.gameObject.CompareTag("Players feet"))
        {
            // Bounce the player
            Rigidbody2D playerRb = collision.gameObject.GetComponentInParent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
            }

            // Optional: disable all enemy colliders before death
            Collider2D[] colliders = transform.parent.GetComponentsInChildren<Collider2D>();
            foreach (Collider2D col in colliders)
            {
                col.enabled = false;
            }

            // Destroy the enemy
            Destroy(transform.parent.gameObject, 0.05f);
        }
    }
}
