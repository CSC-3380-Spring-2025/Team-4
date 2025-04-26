using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;
    public GameObject pauseGamePanel;
    public GameObject healthBar;

 
    [SerializeField] private TMP_Text pointsText;

    private float points;
    public static bool isPaused = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (pauseGamePanel != null) pauseGamePanel.SetActive(false);
        if (healthBar != null) healthBar.SetActive(true);

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
        if (healthBar != null) healthBar.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void PauseGame()
    {
        if (pauseGamePanel != null) pauseGamePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseGamePanel != null) pauseGamePanel.SetActive(false);
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
        Application.Quit();
    }

    public void AddPoints(float pointsToAdd)
    {
        points += pointsToAdd;
        pointsText.text = points.ToString();

    }
}
