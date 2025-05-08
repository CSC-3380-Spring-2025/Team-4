using UnityEngine;

public class BossStomp : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;

    public float bounceForce = 12f;
    public int stompDamage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRb != null && playerRb.linearVelocity.y <= 0)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);

                BossHealth bossHealth = transform.parent.GetComponent<BossHealth>();
                if (bossHealth != null)
                {
                    bossHealth.TakeDamage(stompDamage);
                    gameManager.AddPoints(40);
                    Debug.Log("Boss stomped!");
                }
            }
        }
    }

}
