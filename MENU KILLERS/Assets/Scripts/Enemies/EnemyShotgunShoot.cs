using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotgunShoot : MonoBehaviour
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
        ShotgunBullets();
    }

    private void ShotgunBullets()
    {
        for (int i = 0; i <= 2; i++)
        {
            GameObject bullet = bulletPool.GetObject();
            Vector2 direction = (Vector2)(player.position - firePoint.position);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            switch (i)
            {
                case 0:
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = direction.normalized * bulletSpeed;
                    }
                    break;
                case 1:
                    Quaternion direction2Rotation = Quaternion.Euler(0, 0, 15);
                    Vector2 bullet2Rotation = direction2Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet2Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 2:
                    Quaternion direction3Rotation = Quaternion.Euler(0, 0, -15);
                    Vector2 bullet3Rotation = direction3Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet3Rotation.normalized * bulletSpeed;
                    }
                    break;
            }
        }
    }
}
