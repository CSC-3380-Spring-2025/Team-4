using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class ScrollingCamera : MonoBehaviour
{
    public Transform player;
    private float followSpeed = 2f;
    private bool fallBehindCam = false;

    void Start() {}

    void Update() {
        if (player && !fallBehindCam)
        {
            Vector3 newPos = new Vector3(player.position.x + 1.25f, player.position.y + 4f, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        } else {
            transform.Translate(Vector3.right * Time.deltaTime * (followSpeed / 2));
        }
    }
    
}
