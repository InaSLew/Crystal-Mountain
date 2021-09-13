using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _speed = 5f;
    private float _jumpVelocity = 6f;
    private Rigidbody2D _rb;
    private bool _isGround;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveForward();
        SpaceToJump();
    }

    private void MoveForward()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
    
    private void SpaceToJump()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !_isGround) return;
        _rb.velocity = Vector2.up * _jumpVelocity;
        _isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != "Spike" && other.gameObject.name != "Spike1") CollideWithGround();
    }

    private void CollideWithGround()
    {
        Debug.Log("ON THE GROUND");
        _isGround = true;
    }
}
