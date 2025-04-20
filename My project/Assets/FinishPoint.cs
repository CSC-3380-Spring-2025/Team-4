using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.LoadNextLevel();
        }
    }
}
