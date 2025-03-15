using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float followSpeed = 2f;
    public bool fallBehindCam = false;

    void Update() {
       if (player && !fallBehindCam) { 
            //player still alive
            Vector3 newPos = new Vector3(player.position.x + 1.25f, player.position.y, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
       } else { 
            //continues on path after player dies
            transform.Translate(Vector3.right * Time.deltaTime * (followSpeed / 2)); 
       }
    }
    
}
