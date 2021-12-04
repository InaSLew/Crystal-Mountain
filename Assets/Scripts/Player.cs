using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<Player> ONPlayerDeath;
    public event Action<Player> ONPlayerWin;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) CollideWithEnemy(other);
    }

    private void CollideWithEnemy(Collision2D other)
    {
        var obj = other.gameObject;
        var playerPosition = gameObject.transform.position;
        if (obj.TryGetComponent(out SquareSpike square) && obj.transform.position.y < playerPosition.y)
        {
            Debug.Log("safe side of spike");
            return;
        }

        Debug.Log("not safe side");
        ONPlayerDeath?.Invoke(this);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gate")) CollideWithGate();
        else if (other.CompareTag("Ground")) PlayerIsFalling();
    }
    
    private void CollideWithGate()
    {
        ONPlayerWin?.Invoke(this);
    }

    private void PlayerIsFalling()
    {
        ONPlayerDeath?.Invoke(this);
    }
}
