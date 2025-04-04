using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthmeter;
    [SerializeField] GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame to update health after each hit
    void Update()
    {
        healthmeter.fillAmount = Mathf.Clamp(health / maxHealth,0,1);
        if(health <= 0)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }
}
