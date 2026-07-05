using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionMenuManager : MonoBehaviour
{
    PlayerShoot playerShoot;

    [Header("Attack Cooldowns")]
    public float basicAttackCooldown;
    float basicTimer = 0;
    public float shotgunAttackCooldown;
    float shotgunTimer = 0;
    public float burstAttackCooldown;
    float burstTimer = 0;

    private void Awake()
    {
        playerShoot = FindAnyObjectByType<PlayerShoot>();
    }

    private void Update()
    {
        if (!playerShoot.canBasicShot)
        {
            basicTimer += Time.deltaTime;
        }
        if (basicTimer >= basicAttackCooldown)
        {
            playerShoot.canBasicShot = true;
            basicTimer = 0;
        }

        if (!playerShoot.canShotgunShot)
        {
            shotgunTimer += Time.deltaTime;
        }
        if (shotgunTimer >= shotgunAttackCooldown)
        {
            playerShoot.canShotgunShot = true;
            shotgunTimer = 0;
        }

        if (!playerShoot.canBurstShot)
        {
            burstTimer += Time.deltaTime;
        }
        if (burstTimer >= burstAttackCooldown)
        {
            playerShoot.canBurstShot = true;
            burstTimer = 0;
        }
    }

    public void BasicAttack()
    {
        if (playerShoot.canBasicShot)
        {
            playerShoot.canBasicShot = false;
            playerShoot.BasicBullets();
        }
    }

    public void ShotgunAttack()
    {
        if (playerShoot.canShotgunShot)
        {
            playerShoot.canShotgunShot = false;
            playerShoot.ShotgunBullets();
        }
    }

    public void BurstAttack()
    {
        if (playerShoot.canBurstShot)
        {
            playerShoot.canBurstShot = false;
            playerShoot.BurstBullets();
        }
    }
}
