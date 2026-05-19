using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class PlayerShoot : MonoBehaviour
{
    //public GameObject bulletPrefab;
    public BulletPoolManager bulletPool;
    public Transform aim;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float lastFireTime;
    public bool fireContinuously;

    void Update()
    {
        if (fireContinuously)
        {
            float timeSinceLastFire = Time.time - lastFireTime;
            if (timeSinceLastFire >= timeBetweenShots)
            {
                FireBullet();
                lastFireTime = Time.time;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            fireContinuously = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            fireContinuously = false;
        }
    }

    private void FireBullet()
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

    IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        bulletPool.ReturnObject(bullet);
    }

    private void OnFire(InputValue inputValue)
    {
        fireContinuously = inputValue.isPressed;
    }
}
