using UnityEngine;

public class Damage : MonoBehaviour
{

    public PlayerHealth pHealth;

    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            pHealth.health -= damage;
        }
    }
    
}
