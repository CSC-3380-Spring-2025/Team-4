using UnityEngine;

public class MonsterStomp : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;

    private float bounceForce = 12f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRb != null && playerRb.linearVelocity.y <= 0)
            {
                MonsterDamage bodyDamage = transform.parent.GetComponent<MonsterDamage>();
                if (bodyDamage != null)
                {
                    bodyDamage.hasBeenStomped = true;
                }

                gameManager.AddPoints(5);

                Destroy(transform.parent.gameObject);

                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
                Debug.Log("Stomp success!");
            }
        }
    }
    
}
