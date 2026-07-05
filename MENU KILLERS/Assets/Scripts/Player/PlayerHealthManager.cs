using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    PlayerCollisionManager collisionManager;

    public SpriteRenderer spriteRenderer;
    public float flickerDuration = 0.1f;
    public int flickerCount = 5;

    public GameObject player;
    public GameObject gameOverCanvas;
    public GameObject playerHealthCanvas;

    public float playerHealth;

    public Slider leftHealthSlider;
    public Slider rightHealthSlider;

    public bool damaged = false;
    public float iFrames;

    private void Awake()
    {
        collisionManager = FindAnyObjectByType<PlayerCollisionManager>();
    }

    private void Update()
    {
        if (damaged)
        {
            iFrames += Time.deltaTime;
        }
        if (iFrames >= 2)
        {
            damaged = false;
            iFrames = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        leftHealthSlider.value -= damage;
        rightHealthSlider.value -= damage;
        playerHealth -= damage;
        if (playerHealth > 0)
        {
            StartCoroutine(Damaged());
        }
        else
        {
            //die animation
            playerHealthCanvas.SetActive(false);
            player.SetActive(false);
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;
        }

        damaged = true;
    }

    private IEnumerator Damaged()
    {
        for (int i = 0; i < flickerCount; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(flickerDuration);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(flickerDuration);
        }
    }
}
