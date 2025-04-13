using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     // Start is called once before the first execution of Update after the MonoBehaviour is created

     public GameObject levelOneButton;
     public GameObject levelTwoButton;
     public GameObject levelThreeButton;
     public void LevelOne()
     {
         SceneManager.LoadSceneAsync("Level 1");
     }

     public void LevelTwo()
     {
         SceneManager.LoadSceneAsync("Level 2");
     }

     public void LevelThree()
     {
         SceneManager.LoadSceneAsync("Level 3");
     }

     public void QuitGame()
     {
          Application.Quit();
     }
}
