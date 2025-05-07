using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{

    public float health;
    private float maxHealth;
    private Image healthmeter;

    [SerializeField] private GameManager gameManager;

    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        healthmeter.fillAmount = Mathf.Clamp(health / maxHealth,0,1);

        if(health <= 0)
        {
            gameManager.AddPoints(100);
            Destroy(gameObject);
        }
    }
    
}
