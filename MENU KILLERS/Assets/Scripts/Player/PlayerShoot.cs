using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class PlayerShoot : MonoBehaviour
{
    public BulletPoolManager bulletPool;
    public Transform aim;
    public float bulletSpeed;
    public float burstDelay;

    [Header("Flags")]
    public bool canBasicShot;
    public bool canShotgunShot;
    public bool canBurstShot;

    private void Start()
    {
        canBasicShot = true;
        canShotgunShot = true;
        canBurstShot = true;
    }

    public void BasicBullets()
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = bulletSpeed * transform.up;
        }
    }

    public void ShotgunBullets()
    {
        for (int i = 0; i <= 2; i++)
        {
            GameObject bullet = bulletPool.GetObject();
            Vector2 direction = (Vector2)(transform.up);
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

    public void BurstBullets()
    {
        StartCoroutine(ShootBurstRoutine());
    }

    IEnumerator ShootBurstRoutine()
    {
        for (int i = 0; i <= 2; i++)
        {
            GameObject bullet = bulletPool.GetObject();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = bulletSpeed * transform.up;
            }

            yield return new WaitForSeconds(burstDelay);
        }
    }

    IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        bulletPool.ReturnObject(bullet);
    }
}
