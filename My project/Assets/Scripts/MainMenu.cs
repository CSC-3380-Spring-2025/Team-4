using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject levelOneButton;
    public GameObject levelTwoButton;
    public GameObject levelThreeButton;

    public void LevelOne()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void LevelTwo()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void LevelThree()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
