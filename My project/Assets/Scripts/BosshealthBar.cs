using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{

    private BossHealth bossHealth;
    private Image healthFill;

    void Update()
    {
        if (bossHealth != null && healthFill != null)
        {
            healthFill.fillAmount = (float)bossHealth.CurrentHealth / bossHealth.MaxHealth;
        }
    }
    
}
