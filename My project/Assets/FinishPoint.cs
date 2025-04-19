using UnityEngine;

public class FinishPoint : MonoBehaviour
{

    [SerializeField] bool goToNextLevel;
    [SerializeField] string goToLevelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (goToNextLevel) {
                SceneController.instance.NextLevel();
            }
            else
            {
                SceneController.instance.SpecifiedLevel(goToLevelName);
            }
        }
    }
}
