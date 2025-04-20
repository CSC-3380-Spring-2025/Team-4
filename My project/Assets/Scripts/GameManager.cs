using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pauseGamePanel;
    public GameObject healthBar;
    public static bool isPaused = false;
    public static GameManager instance;

    private void Awake()
    {
        // Singleton pattern to make sure only one GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keep between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("No more levels to load!");
        }
    }
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
