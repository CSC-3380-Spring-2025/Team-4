using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public Transform playerTransform; // Assign this in the Inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == playerTransform)
        {
            SceneController.instance.LoadNextLevel();
        }
    }
}
