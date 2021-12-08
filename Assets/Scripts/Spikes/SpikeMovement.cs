using System;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
    }
}
