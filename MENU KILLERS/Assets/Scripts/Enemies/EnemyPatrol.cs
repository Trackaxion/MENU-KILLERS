using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Detection detection;

    public float moveSpeed;

    [Header("Patrol")]
    public float startWaitTime;
    private float waitTime;
    public Transform wayPoint;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float stoppingDistance;
    public float retreatDistance;
    [HideInInspector] public Transform player;

    private void Awake()
    {
        detection = GetComponent<Detection>();
    }

    private void Start()
    {
        waitTime = startWaitTime;
        wayPoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!detection.hasDetected)
        {
            Patrol();
        }
        else if (detection.hasDetected)
        {
            FollowPlayer();
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoint.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                wayPoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
    }
}
