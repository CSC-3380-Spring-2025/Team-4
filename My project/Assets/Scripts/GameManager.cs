using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("UI Refs:")]
    public GameObject gameOverPanel;
    public GameObject pauseGamePanel;
    public GameObject healthBar;
    public GameObject pointsPanel;

    [Header("Points:")]
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private TMP_Text gameOverPointsText;
    private float points;

    public static bool isPaused = false;

    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (pauseGamePanel != null)
        {
            pauseGamePanel.SetActive(false);
        } 

        if (healthBar != null)
        {
            healthBar.SetActive(true);
        } 

        if (pointsPanel != null) 
        {
            pointsPanel.SetActive(true);
        }

        points = PlayerPrefs.HasKey("Points") ? PlayerPrefs.GetFloat("Points") : 0;
        ResumeGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseGamePanel == null) return;

            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void GameOver()
    {
        if (healthBar != null) 
        {
            healthBar.SetActive(false);
        }

        if (pointsPanel != null) 
        {
            pointsPanel.SetActive(false);
        }

        if (gameOverPanel != null) 
        {
            gameOverPanel.SetActive(true);
        }

        gameOverPointsText.text = points.ToString();
    }

    public void RestartGame()
    {
        PlayerPrefs.SetFloat("Points", 0);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void PauseGame()
    {
        if (pauseGamePanel != null) 
        {
            pauseGamePanel.SetActive(true);
        }

        if (pointsPanel != null) 
        {
            pointsPanel.SetActive(false);
        }

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseGamePanel != null) 
        {
            pauseGamePanel.SetActive(false);
        }

        if (pointsPanel != null) 
        {
            pointsPanel.SetActive(true);
        }

        Time.timeScale = 1f;
        isPaused = false;
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

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteKey("Points");
        Application.Quit();
    }

    public void AddPoints(float pointsToAdd)
    {
        points += pointsToAdd;
        pointsText.text = points.ToString();
        PlayerPrefs.SetFloat("Points", points);
    }
    
}
