using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamakazi : MonoBehaviour
{
    EnemyPatrol enemyPatrol;
    EnemyBulletPoolManager bulletPool;
    public Transform firePoint;
    private bool isQuiting = false;

    public float bulletSpeed;

    private void Awake()
    {
        enemyPatrol = GetComponent<EnemyPatrol>();
        bulletPool = FindAnyObjectByType<EnemyBulletPoolManager>();
    }

    private void SelfDestruct()
    {
        for (int i = 0; i <= 23; i++)
        {
            GameObject bullet = bulletPool.GetObject();
            Vector2 direction = (Vector2)(enemyPatrol.player.position - firePoint.position);
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
                case 3:
                    Quaternion direction4Rotation = Quaternion.Euler(0, 0, 30);
                    Vector2 bullet4Rotation = direction4Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet4Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 4:
                    Quaternion direction5Rotation = Quaternion.Euler(0, 0, -30);
                    Vector2 bullet5Rotation = direction5Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet5Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 5:
                    Quaternion direction6Rotation = Quaternion.Euler(0, 0, 45);
                    Vector2 bullet6Rotation = direction6Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet6Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 6:
                    Quaternion direction7Rotation = Quaternion.Euler(0, 0, -45);
                    Vector2 bullet7Rotation = direction7Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet7Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 7:
                    Quaternion direction8Rotation = Quaternion.Euler(0, 0, 60);
                    Vector2 bullet8Rotation = direction8Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet8Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 8:
                    Quaternion direction9Rotation = Quaternion.Euler(0, 0, -60);
                    Vector2 bullet9Rotation = direction9Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet9Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 9:
                    Quaternion direction10Rotation = Quaternion.Euler(0, 0, 75);
                    Vector2 bullet10Rotation = direction10Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet10Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 10:
                    Quaternion direction11Rotation = Quaternion.Euler(0, 0, -75);
                    Vector2 bullet11Rotation = direction11Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet11Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 11:
                    Quaternion direction12Rotation = Quaternion.Euler(0, 0, 90);
                    Vector2 bullet12Rotation = direction12Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet12Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 12:
                    Quaternion direction13Rotation = Quaternion.Euler(0, 0, -90);
                    Vector2 bullet13Rotation = direction13Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet13Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 13:
                    Quaternion direction14Rotation = Quaternion.Euler(0, 0, 105);
                    Vector2 bullet14Rotation = direction14Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet14Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 14:
                    Quaternion direction15Rotation = Quaternion.Euler(0, 0, -105);
                    Vector2 bullet15Rotation = direction15Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet15Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 15:
                    Quaternion direction16Rotation = Quaternion.Euler(0, 0, 120);
                    Vector2 bullet16Rotation = direction16Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet16Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 16:
                    Quaternion direction17Rotation = Quaternion.Euler(0, 0, -120);
                    Vector2 bullet17Rotation = direction17Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet17Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 17:
                    Quaternion direction18Rotation = Quaternion.Euler(0, 0, 135);
                    Vector2 bullet18Rotation = direction18Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet18Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 18:
                    Quaternion direction19Rotation = Quaternion.Euler(0, 0, -135);
                    Vector2 bullet19Rotation = direction19Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet19Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 19:
                    Quaternion direction20Rotation = Quaternion.Euler(0, 0, 150);
                    Vector2 bullet20Rotation = direction20Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet20Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 20:
                    Quaternion direction21Rotation = Quaternion.Euler(0, 0, -150);
                    Vector2 bullet21Rotation = direction21Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet21Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 21:
                    Quaternion direction22Rotation = Quaternion.Euler(0, 0, 165);
                    Vector2 bullet22Rotation = direction22Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet22Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 22:
                    Quaternion direction23Rotation = Quaternion.Euler(0, 0, -165);
                    Vector2 bullet23Rotation = direction23Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet23Rotation.normalized * bulletSpeed;
                    }
                    break;
                case 23:
                    Quaternion direction24Rotation = Quaternion.Euler(0, 0, 180);
                    Vector2 bullet24Rotation = direction24Rotation * direction;
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    if (rb != null)
                    {
                        rb.velocity = bullet24Rotation.normalized * bulletSpeed;
                    }
                    break;
            }
        }
    }

    private void OnApplicationQuit()
    {
        isQuiting = true;
    }

    private void OnDestroy()
    {
        if (isQuiting)
        {
            return;
        }
        SelfDestruct();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
