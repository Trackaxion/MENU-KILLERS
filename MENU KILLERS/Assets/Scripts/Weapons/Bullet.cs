using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera mainCamera;
    BulletPoolManager bulletPool;
    private float bulletTimer;

    private void Awake()
    {
        mainCamera = Camera.main;
        bulletPool = FindAnyObjectByType<BulletPoolManager>();
    }

    private void OnEnable()
    {
        bulletTimer = 0;
    }

    private void Update()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= 2)
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
        if (collision.tag == "TestEnemy")
        {
            Destroy(collision.gameObject);
            ReturnToPool(this.gameObject);
        }
    }
}
