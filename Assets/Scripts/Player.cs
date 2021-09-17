using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<Player> ONPlayerDeath;
    public event Action<Player> ONPlayerWin;
    public AudioSource death;
    public AudioSource throughTheGate;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) CollideWithEnemy(other);
    }

    private void CollideWithEnemy(Collision2D enemy)
    {
        var enemyObj = enemy.gameObject;
        var playerPosition = gameObject.transform.position;
        if (enemyObj.name.Contains("SquareSpike") && enemyObj.transform.position.y < playerPosition.y)
        {
            Debug.Log("HIT SAFE SIDE ON SPIKE");
            return;
        }
        death.Play();
        ONPlayerDeath?.Invoke(this);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gate")) CollideWithGate();
        else if (other.CompareTag("Ground")) PlayerIsFalling();
    }
    
    private void CollideWithGate()
    {
        throughTheGate.Play();
        ONPlayerWin?.Invoke(this);
    }

    private void PlayerIsFalling()
    {
        death.Play();
        ONPlayerDeath?.Invoke(this);
    }
}
