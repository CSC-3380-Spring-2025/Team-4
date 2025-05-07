using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public BossHealth bossHealth;
    public Image healthFill;

    void Update()
    {
        if (bossHealth != null && healthFill != null)
        {
            healthFill.fillAmount = (float)bossHealth.CurrentHealth / bossHealth.MaxHealth;
        }

        // Optional: rotate to face camera if using 3D
        // transform.rotation = Quaternion.identity;
    }
}
