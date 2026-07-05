using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPowerMover : MonoBehaviour
{
    public float startingSpot;
    public float endingSpot;
    public float moveSpeed;
    private Rigidbody2D rb;
    public GameObject collisionObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == collisionObject)
        {
            transform.position = new Vector2(startingSpot, transform.position.y);
        }
    }
}
