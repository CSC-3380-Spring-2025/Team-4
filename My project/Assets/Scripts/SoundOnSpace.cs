using UnityEngine;
 
public class SoundOnSpace : MonoBehaviour
{
    public AudioSource someSound;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            someSound.Play();
        }
    }
    
}
