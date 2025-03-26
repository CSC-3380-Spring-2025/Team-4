using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleSoundController : MonoBehaviour
{
    public AudioSource firstSoundEffect;
    public AudioSource secondSoundEffect;
    public TextMeshProUGUI startText;

    void Start()
    {
        StartCoroutine(PlaySoundsAndShowText());
    }

    IEnumerator PlaySoundsAndShowText()
    {
        if (firstSoundEffect != null)
        {
            firstSoundEffect.Play();
            yield return new WaitForSeconds(firstSoundEffect.clip.length);
        }

        if (secondSoundEffect != null)
        {
            secondSoundEffect.Play();
            yield return new WaitForSeconds(secondSoundEffect.clip.length);
        }

        if (startText != null)
        {
            startText.gameObject.SetActive(true);
            StartCoroutine(BlinkText());
        }
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            startText.enabled = false;
            yield return new WaitForSeconds(0.5f);
            startText.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update() {
    if (startText != null && startText.gameObject.activeSelf && Input.anyKeyDown) {
        StopAllCoroutines();
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
    }
}
