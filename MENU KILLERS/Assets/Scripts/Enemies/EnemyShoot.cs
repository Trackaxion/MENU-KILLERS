using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    Detection detection;
    EnemyBulletPoolManager bulletPool;
    public Transform player;
    public Transform firePoint;

    public float bulletSpeed;
    public float fireRate;
    private float nextFireTime;

    private void Awake()
    {
        bulletPool = FindAnyObjectByType<EnemyBulletPoolManager>();
        detection = GetComponent<Detection>();
    }

    private void Update()
    {
        if (detection.hasDetected)
        {
            if (Time.time >= nextFireTime)
            {
                FireBullet();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    private void FireBullet()
    {
        Vector2 direction = (Vector2)(player.position - firePoint.position);
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = direction.normalized * bulletSpeed;
        }
    }
}
