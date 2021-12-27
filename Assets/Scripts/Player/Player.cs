using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameEvent playerIsDead;
    public event Action<Player> ONPlayerWin; // <--- Retire target

    public void OnCollideWithEnemy() => playerIsDead.Raise();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gate")) CollideWithGate();
        else if (other.CompareTag("Ground")) PlayerIsFalling();
    }
    
    private void CollideWithGate() => ONPlayerWin?.Invoke(this);

    private void PlayerIsFalling() => playerIsDead.Raise();
}
