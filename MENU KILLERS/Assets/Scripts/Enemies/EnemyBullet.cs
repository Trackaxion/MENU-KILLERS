using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    PlayerCollisionManager collisionManager;
    EnemyBulletPoolManager bulletPool;
    private float bulletTimer;

    private void Awake()
    {
        collisionManager = FindAnyObjectByType<PlayerCollisionManager>();
        bulletPool = FindAnyObjectByType<EnemyBulletPoolManager>();
    }

    private void OnEnable()
    {
        bulletTimer = 0;
    }

    private void Update()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= 4)
        {
            ReturnToPool(this.gameObject);
        }
    }

    private void ReturnToPool(GameObject bullet)
    {
        bulletPool.ReturnObject(bullet);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collisionManager.invulnerable == false)
        {
            ReturnToPool(this.gameObject);
        }
    }
}
