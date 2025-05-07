using UnityEngine;
 
 public class SoundOnR : MonoBehaviour
 {
     public AudioSource someSound;
     // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
     {
         
     }
 
     // Update is called once per frame
     void Update()
     {
         if(Input.GetKeyDown(KeyCode.R)){
             someSound.Play();
         }
     }
 }
