using UnityEngine;

public class Damage : MonoBehaviour
{

    private PlayerHealth playerHealth;

    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.health -= damage;
        }
    }

}
