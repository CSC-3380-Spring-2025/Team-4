using UnityEngine;
using System.Collections;
using TMPro;

public class TitleSoundController : MonoBehaviour
{

    public AudioSource firstSoundEffect;
    public AudioSource secondSoundEffect;
    public TextMeshProUGUI startText;

    void Start()
    {
        startText.gameObject.SetActive(false);
        StartCoroutine(iPlaySoundsAndShowText());
    }

    IEnumerator iPlaySoundsAndShowText()
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
            StartCoroutine(iBlinkText());
        }
    }

    IEnumerator iBlinkText()
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
        SceneController.instance.NextLevel();
        }
    }
    
}
