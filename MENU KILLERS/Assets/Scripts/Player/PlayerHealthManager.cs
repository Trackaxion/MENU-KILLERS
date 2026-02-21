using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Stats")]
    public float playerHealth;
    public float maxPlayerHealth;

    public GameObject player;
    public GameObject gameOverCanvas;
    public GameObject playerHealthCanvas;

    private void Start()
    {
        playerHealth = maxPlayerHealth;
    }

    public void TakeDamage(int damage)
    {
        playerHealth = Mathf.Clamp(playerHealth - damage, 0, maxPlayerHealth);
        if (playerHealth > 0)
        {
            //hurt animation
        }
        else
        {
            //die animation
            playerHealthCanvas.SetActive(false);
            player.SetActive(false);
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
