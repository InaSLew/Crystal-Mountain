using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<Player> ONPlayerDeath;
    public event Action<Player> ONPlayerWin;
    [SerializeField] private BooleanValue isOnGround;

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Enemy")) CollideWithEnemy(other);
    // }

    public void OnCollideWithEnemy()
    {
        Debug.Log("OnCollideWithEnemy fired");
        ONPlayerDeath?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gate")) CollideWithGate();
        else if (other.CompareTag("Ground")) PlayerIsFalling();
    }
    
    private void CollideWithGate() => ONPlayerWin?.Invoke(this);

    private void PlayerIsFalling() => ONPlayerDeath?.Invoke(this);
}
