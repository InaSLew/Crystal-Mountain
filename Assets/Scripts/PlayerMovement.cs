using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 2f;
    private float _jumpVelocity = 5f;
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
        _rb.AddForce(Vector2.right * _speed, ForceMode2D.Force);
    }
    
    private void SpaceToJump()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !_isGround) return;
        _rb.AddForce(Vector2.up * _jumpVelocity, ForceMode2D.Impulse);
        _isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) CollideWithGround();
    }

    private void CollideWithGround()
    {
        Debug.Log("ON THE GROUND");
        _isGround = true;
    }
}
