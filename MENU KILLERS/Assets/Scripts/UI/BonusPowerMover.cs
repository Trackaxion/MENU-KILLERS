using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPowerMover : MonoBehaviour
{
    public float startingSpot;
    public float endingSpot;
    public float moveSpeed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x <= endingSpot)
        {
            transform.position = new Vector2(startingSpot, transform.position.y);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
