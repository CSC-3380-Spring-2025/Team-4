using UnityEngine;

public class BossPatrol : MonoBehaviour
{

    public Transform[] patrolPoints;

    public float normalSpeed = 2f;
    public float fastSpeed = 4f;
    private float currentSpeed;
    private bool isSpeedingUp = false;

    private int currentPointIndex = 0;
    private int patrolCycleCount = 0;
    private int stepsInCycle = 0;

    private SpriteRenderer spriteRenderer;

    public bool IsSpeedingUp()
    {
        return isSpeedingUp;
    }

    void Start()
    {
        if (patrolPoints.Length < 3)
        {
            Debug.LogError("Please assign 3 patrol points to BossPatrol.");
            enabled = false;
            return;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("BossPatrol requires a SpriteRenderer component on the same GameObject.");
            enabled = false;
            return;
        }

        currentSpeed = normalSpeed;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, currentSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            if (currentPointIndex == 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (currentPointIndex == 1 && GetNextIndex() == 2)
            {
                spriteRenderer.flipX = false;
            }

            currentPointIndex = GetNextIndex();
            stepsInCycle++;

            if (stepsInCycle >= patrolPoints.Length)
            {
                patrolCycleCount++;
                stepsInCycle = 0;

                if (!isSpeedingUp && patrolCycleCount % 2 == 1)
                {
                    currentSpeed = fastSpeed;
                    isSpeedingUp = true;
                }
                else
                {
                    currentSpeed = normalSpeed;
                    isSpeedingUp = false;
                }
            }
        }
    }

    int GetNextIndex()
    {
        return (currentPointIndex + 1) % patrolPoints.Length;
    }
    
}
