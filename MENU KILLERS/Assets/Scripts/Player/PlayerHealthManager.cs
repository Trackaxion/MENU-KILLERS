using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Stats")]
    public float playerHealth;
    public float maxPlayerHealth;

    private void Start()
    {
        playerHealth = maxPlayerHealth;
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
    }
}
