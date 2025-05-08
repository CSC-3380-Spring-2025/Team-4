using UnityEngine;
 
public class SoundOnR : MonoBehaviour
{

    public AudioSource someSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            someSound.Play();
        }
    }

}
