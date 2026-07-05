using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    PlayerHealthManager playerHealth;

    public int testEnemyDamage;
    public int testEnemyBulletDamage;

    public bool invulnerable;

    private void Awake()
    {
        invulnerable = false;
        playerHealth = FindAnyObjectByType<PlayerHealthManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TestEnemy" && invulnerable == false && playerHealth.damaged == false)
        {
            playerHealth.TakeDamage(testEnemyDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TestBullet" && invulnerable == false && playerHealth.damaged == false)
        {
            playerHealth.TakeDamage(testEnemyBulletDamage);
        }
    }
}
