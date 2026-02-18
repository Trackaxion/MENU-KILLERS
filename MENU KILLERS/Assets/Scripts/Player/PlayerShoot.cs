using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
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
        GameObject bullet = Instantiate(bulletPrefab, aim.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bulletSpeed * transform.up;
    }

    private void OnFire(InputValue inputValue)
    {
        fireContinuously = inputValue.isPressed;
    }
}
