using UnityEngine;

public class PlayerStomp : MonoBehaviour
{
    public float bounceForce = 2f; // Adjust for jump height

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weak Point"))
        {
            // Bounce the player
            Rigidbody2D playerRb = GetComponentInParent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
            }

            // Destroy the enemy (assuming the weak point is a child of the enemy root)
            GameObject enemy = collision.transform.parent.gameObject;
            Destroy(enemy);
        }
    }
}
