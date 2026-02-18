using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerHealthManager playerHealth;
    public Image totalHealthBar;
    public Image currentHealthBar;

    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.maxPlayerHealth / 10;
    }

    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.playerHealth / 10;
    }
}
