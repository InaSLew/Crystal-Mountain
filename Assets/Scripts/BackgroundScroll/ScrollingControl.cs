using System;
using UnityEngine;

public class ScrollingControl : MonoBehaviour
{
    [SerializeField] private FloatValue scrollSpeed;
    [SerializeField] private BooleanValue isGameOver;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * scrollSpeed.Float;
    }

    void Update()
    {
        if (isGameOver.BoolValue) rb.velocity = Vector2.zero;
    }
}
