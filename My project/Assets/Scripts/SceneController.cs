using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static SceneController instance;
    [SerializeField] private Animator transitionAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        StartCoroutine(iLoadNextLevel());
    }

    public void SpecifiedLevel(string sceneName)
    {
        StartCoroutine(iLoadSpecifiedLevel(sceneName));
    }
    
    IEnumerator iLoadSpecifiedLevel(string sceneName)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForSeconds(1);
        transitionAnim.SetTrigger("Start");
    }

    IEnumerator iLoadNextLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        yield return new WaitForSeconds(1);
        transitionAnim.SetTrigger("Start");
    }
    
}
