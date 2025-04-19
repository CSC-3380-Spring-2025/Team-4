using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pauseGamePanel;
    public GameObject healthBar;
    public static bool isPaused = false;
    public void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
        pauseGamePanel.gameObject.SetActive(false);
        healthBar.gameObject.SetActive(true);
        ResumeGame();
    }

     public void Update()
    {

    }

    public void GameOver() 
    {
        //Calc score
        healthBar.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void PauseGame()
    {
        pauseGamePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseGamePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
