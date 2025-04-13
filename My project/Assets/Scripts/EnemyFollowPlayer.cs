using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float stopDistance = 0.1f; // Distance considered "close enough" to stop

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance > stopDistance)
            {
                Vector2 currentPosition = transform.position;
                Vector2 targetPosition = player.position;
                transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                // Optional: attack or interact here
                Debug.Log("Enemy is close enough to attack!");
            }
        }
    }
}
