using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    public Enemy_Health pHealth;
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            pHealth.health -= damage;
        }
    }
}
