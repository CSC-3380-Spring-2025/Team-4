using UnityEngine;

public class MonsterStomp : MonoBehaviour
{
    public float bounceForce = 10f; // You can adjust this

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the whole enemy (this assumes the head is a child)
            Destroy(transform.parent.gameObject);

            // Bounce the player upward
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
            }
        }
    }
}