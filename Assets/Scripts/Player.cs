using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<Player> ONPlayerDeath;
    public event Action<Player> ONPlayerWin;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) CollideWithEnemy(other);
        else if (other.gameObject.CompareTag("Gate")) CollideWithGate(other);
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
        ONPlayerDeath?.Invoke(this);
    }
    
    private void CollideWithGate(Collision2D other)
    {
        ONPlayerWin?.Invoke(this);
    }
}
