using UnityEngine;
// used to deal damage to the players
public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth;
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
        if(collision.gameObject.CompareTag("Player"))
        {
            pHealth.health -= damage;
        }
    }
}
