using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public GameObject player;
    private float damage;
    public float testEnemyDamage;
    public PlayerHealthManager playerHealth;

    private void Start()
    {
        DamageType();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void DamageType()
    {
        if (CompareTag("TestEnemy"))
        {
            damage = testEnemyDamage;
        }
    }
}
