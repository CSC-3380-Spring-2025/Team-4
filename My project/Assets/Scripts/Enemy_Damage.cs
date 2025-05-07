using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{

    private Enemy_Health enemyHealth;
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            enemyHealth.health -= damage;
        }
    }
    
}
