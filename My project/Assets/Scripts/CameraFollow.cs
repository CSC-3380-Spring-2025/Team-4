using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private float followSpeed = 2f;

    private Transform target;

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
    
}
