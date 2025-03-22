using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    private SpriteMovement player;
    public void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
    }

     public void Update()
    {
        
    }

    public void GameOver() 
    {
        //Calc score
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
